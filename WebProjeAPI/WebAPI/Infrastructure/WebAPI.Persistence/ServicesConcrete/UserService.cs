using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.Dtos;
using WebAPI.Application.Repositories.RoleRepo;
using WebAPI.Application.Repositories.UserRepo;
using WebAPI.Application.Results;
using WebAPI.Application.Services;
using WebAPI.Application.ViewModels;
using WebAPI.Domain.Entities;
using WebAPI.Persistence.ResultConcrete;

namespace WebAPI.Persistence.ServicesConcrete
{
	public class UserService : IUserService
	{
		private IUserReadRepository _userReadRepository;
		private IUserWriteRepository _userWriteRepository;
		private IRoleReadRepository _roleReadRepository;

		public UserService(IUserReadRepository readRepository, IUserWriteRepository writeRepository
			, IRoleReadRepository roleReadRepository)
		{
			_userReadRepository = readRepository;
			_userWriteRepository = writeRepository;
			_roleReadRepository = roleReadRepository;
		}

		public async Task<IResult> CreateUser(CreateUser user, string RoleName)
		{
			var roles = new List<Role>();
			var role = await _roleReadRepository.GetSingleAsync(r => r.RoleName == RoleName);
			if (role != null)
			{
				roles.Add(role);
			}
			else
			{
				roles.Add(new Role() { RoleName = RoleName });
			}

			await _userWriteRepository.AddAsync(new()
			{
				Id = Guid.NewGuid(),
				FirstName = user.FirstName,
				LastName = user.LastName,
				Password = user.Password,
				UserName = user.UserName,
				ImageURL = user.ImageURL,
				Roles = roles

			});
			try
			{
				await _userWriteRepository.SaveAsync();
				return new SuccessResult();
			}
			catch (Exception ex)
			{
				return new ErrorResult(ex.Message);
			}


		}


		//burasi test edilecek
		public async Task<IResult> DeleteUser(DeleteUserDto User)
		{
			var query = _userReadRepository.GetWhere(u => u.UserName == User.UserName);
			var user = query.Include(p => p.Blogs).ThenInclude(a => a.Comments).FirstOrDefault();
			if (user != null)
			{
				if (user.Blogs.Count != 0)
				{
					foreach (var blog in user.Blogs)
					{
						blog.Status = false;
						foreach (var comment in blog.Comments)
						{
							comment.Status = false;

						}
					}
				}
				user.Status = false;
				try
				{
					_userWriteRepository.Update(user);
					await _userWriteRepository.SaveAsync();
					return new SuccessResult();
				}
				catch (Exception ex)
				{
					return new ErrorResult(ex.Message);
				}

			}
			//buraya messsage sinifi yazilacak
			return new ErrorResult("kullanici yok");
		}

		public IDataResult<UserViewModel> GetUserByUserName(string userName)
		{
			//var user = _userReadRepository.GetWhere(c => c.UserName == userName).FirstOrDefault();
			var query =from u in _userReadRepository.GetWhere(c=>c.UserName == userName)
					   select new UserViewModel()
					   {
						  RoleName=u.Roles.FirstOrDefault()==null? string.Empty: u.Roles.FirstOrDefault()!.RoleName,
						  FirstName=u.FirstName,
						  LastName=u.LastName,
						  Password=u.Password,
						  UserID=u.Id,
						  UserName=u.UserName,
						  


					   };
			var user= query.FirstOrDefault();
			//UserViewModel userDto;
			//if (user != null)
			//{
			//	userDto = new UserViewModel()
			//	{
			//		UserName = user.UserName,
			//		FirstName = user.FirstName,
			//		LastName = user.LastName,
			//		password = user.Password,
			//		UserID = user.Id
			//	};

			//}
			//else
			//{
			//	userDto = default;
			//}
			//userDto
			return new SuccessDataResult<UserViewModel>(user);
		}
	}
}
