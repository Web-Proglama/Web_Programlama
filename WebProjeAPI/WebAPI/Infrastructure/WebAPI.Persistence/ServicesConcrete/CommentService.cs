using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.Dtos;
using WebAPI.Application.Repositories.CommentRepo;
using WebAPI.Application.Repositories.UserRepo;
using WebAPI.Application.Results;
using WebAPI.Application.Services;
using WebAPI.Application.ViewModels;
using WebAPI.Persistence.ResultConcrete;

namespace WebAPI.Persistence.ServicesConcrete
{
    public class CommentService : ICommentService
    {
        private ICommentReadRepository _commentReadRepository;
        private ICommentWriteRepository _commentWriteRepository;
        private IUserReadRepository _userReadRepository;

		public CommentService(ICommentReadRepository commentReadRepository, ICommentWriteRepository commentWriteRepository, IUserReadRepository userReadRepository)
		{
			_commentReadRepository = commentReadRepository;
			_commentWriteRepository = commentWriteRepository;
			_userReadRepository = userReadRepository;
		}

		public async Task<IResult> addCommentAsync(AddCommentDto commentDto)
        {
            try
            {
                 await _commentWriteRepository.AddAsync(new()
                {
                    BlogId= commentDto.BlogId,
                    Status=true,
                    Id=Guid.NewGuid(),
                    Content=commentDto.Content,
                    UserName=commentDto.UserName
                    
                });
              await  _commentWriteRepository.SaveAsync();
                    return new SuccessResult();
           
            }
            catch (Exception)
            {

                return new ErrorResult();
            }
        }

		public IDataResult<List<CommentWithImage>> GetCommentsByBlogId(string blogId)
		{
            var query = from e in _commentReadRepository.GetWhere(c => c.BlogId == Guid.Parse(blogId))
                        join k in _userReadRepository.GetAll() on e.UserName equals k.UserName
                        select new CommentWithImage()
                        {
                            ImageURL= k.ImageURL,
                            BlogId=e.BlogId,
                            Content=e.Content,
                            FirstName=k.FirstName,
                            LastName=k.LastName,
                            UserId=k.Id,
                            userName=k.UserName
                        };
            var result=query.ToList();
            return new SuccessDataResult<List<CommentWithImage>>(result);
		}
	}
}
