using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.Dtos;
using WebAPI.Application.Repositories.BlogRepo;
using WebAPI.Application.Repositories.CategoryRepo;
using WebAPI.Application.Results;
using WebAPI.Application.Services;
using WebAPI.Application.ViewModels;
using WebAPI.Domain.Entities;
using WebAPI.Persistence.ResultConcrete;

namespace WebAPI.Persistence.ServicesConcrete
{
	public class BlogService : IBlogService
	{
		private IBlogReadRepository _blogReadRepository;
		private IBlogWriteRepository _blogWriteRepository;
		private ICategoryReadRepository _categoryReadRepository;

		public BlogService(IBlogReadRepository blogReadRepository, IBlogWriteRepository blogWriteRepository, ICategoryReadRepository categoryReadRepository)
		{
			_categoryReadRepository = categoryReadRepository;
			_blogReadRepository = blogReadRepository;
			_blogWriteRepository = blogWriteRepository;
		}

		public async Task<IDataResult<Blog>> AddBlogAsync(AddBlogDto addBlog)
		{
			var category = await _categoryReadRepository.GetSingleAsync(name => name.CategoryName == addBlog.CategoryName);
			var categories = new List<Category>();
			if (category != null)
			{
				categories.Add(category);
			}
			else
			{
				categories.Add(new Category()
				{
					Id = Guid.NewGuid(),
					CategoryName = addBlog.CategoryName
				});
			}
			var blog = new Blog()
			{
				Id = Guid.NewGuid(),
				Content = addBlog.BlogContent,
				Status = true,
				Title = addBlog.Blogtitle,
				UserId = addBlog.UserId,
				Categories = categories,
				ImageURL = addBlog.ImageURL
			};
			try
			{
				await _blogWriteRepository.AddAsync(blog);
				await _blogWriteRepository.SaveAsync();
				return new SuccessDataResult<Blog>(blog);
			}
			catch (Exception e)
			{
				return new ErrorDataResult<Blog>(e.Message);
			}


		}


		public IDataResult<List<AllBlogsViewModel>> GetBlogByCategory(string categoryId)
        {

			var categories = _categoryReadRepository.GetWhere(k => k.Id == Guid.Parse(categoryId)).Include(c => c.Blogs).FirstOrDefault();
			var blogs =new  List<AllBlogsViewModel>();
			foreach (var item in categories.Blogs)
			{
				blogs.Add(new()
				{
					ImageURL= item.ImageURL,
					CratedDate=item.CreatedDate,
					BlogId=item.Id,
					Title= item.Title,
					Content= item.Content,
					Status= item.Status,
					
				});
			}
			return new SuccessDataResult<List<AllBlogsViewModel>>(blogs);
        }

        public async Task<IDataResult<BlogViewModel>> GetBlogById(string id)
		{
			try
			{
				var data = await _blogReadRepository.GetByIdAsync(id, false);
				var result = from e in _blogReadRepository.GetWhere(d => d.Id == Guid.Parse(id))
							 select new BlogViewModel()
							 {
								 BlogId = e.Id,
								 Title = e.Title,
								 Status = e.Status,
								 FullName = e.User.FirstName + " " + e.User.LastName,
								 // Comments=e.Comments.ToList(),
								 UserId = e.UserId,
								 Content = e.Content,
								 ImageURL = e.ImageURL,
								 CreatedDate = e.CreatedDate
							 };
				var sonuc = result.FirstOrDefault();
				return new SuccessDataResult<BlogViewModel>(sonuc);
			}
			catch (Exception e)
			{
				return new ErrorDataResult<BlogViewModel>(e.Message);
			}


		}

		public IDataResult<List<Blog>> GetBlogByName(string title)
		{
			try
			{
				var blogList = _blogReadRepository.GetWhere(c => c.Title == title, false).ToList();
				return new SuccessDataResult<List<Blog>>(blogList);
			}
			catch (Exception e)
			{
				return new ErrorDataResult<List<Blog>>(e.Message);
			}

		}

		public IDataResult<List<AllBlogsViewModel>> GetBlogList()
		{
			try
			{
				var blogList = from e in _blogReadRepository.GetAll().Include(u => u.User)
							   select new AllBlogsViewModel()
							   {
								   BlogId = e.Id,
								   ImageURL = e.ImageURL,
								   Title = e.Title,
								   Content = e.Content,
								   Status = e.Status,
								  // UserFirstName = e.User.FirstName,
								  // UserLastName = e.User.LastName,
								   CratedDate = e.CreatedDate

							   };
				return new SuccessDataResult<List<AllBlogsViewModel>>(blogList.ToList());
			}
			catch (Exception e)
			{
				return new ErrorDataResult<List<AllBlogsViewModel>>(e.Message);
			}


		}

        public IDataResult<List<AllBlogsViewModel>> GetRecentBlogs()
        {
			var datas = (from e in _blogReadRepository.GetAll().OrderByDescending(u => u.CreatedDate).Take(4)
						select new AllBlogsViewModel()
						{
							CratedDate= e.CreatedDate,
							BlogId=e.Id,
							Content=e.Content,
							ImageURL=e.ImageURL,
							Status= e.Status,
							Title=e.Title
						}).ToList();
			return new SuccessDataResult<List<AllBlogsViewModel>>(datas);
        }

		public async Task<IResult> DeleteBlogByIdAsync(string id)
		{
			
			var result= await _blogWriteRepository.Remove(id);
			await _blogWriteRepository.SaveAsync();
			if (result)
			{
				return new SuccessResult();
			}
			return new ErrorResult();
		}

		public async Task<IResult> EditBlog(EditBlogGet eblog)
		{
			try
			{
				var blog = await _blogReadRepository.GetByIdAsync(eblog.BlogID.ToString());
				blog.Title = eblog.Title;
				blog.Content = eblog.Content;
				var boolValue=_blogWriteRepository.Update(blog);
				await _blogWriteRepository.SaveAsync();
				if (boolValue)
				{
					return new SuccessResult();
				}
				return new ErrorResult();
				

			}catch(Exception ex)
			{
				return new ErrorResult();
			}
		
			
		}
	}
}
