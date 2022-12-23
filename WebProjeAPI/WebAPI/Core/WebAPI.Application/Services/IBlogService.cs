using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.Dtos;
using WebAPI.Application.Results;
using WebAPI.Application.ViewModels;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Services
{
    public interface IBlogService
    {
        Task<IDataResult<Blog>> AddBlogAsync(AddBlogDto addBlog);
        IDataResult<List<AllBlogsViewModel>> GetBlogList();
        IDataResult<List<Blog>> GetBlogByName(string title);
        Task<IDataResult<BlogViewModel>> GetBlogById(string id);
        IDataResult<List<AllBlogsViewModel>> GetBlogByCategory(string categoryId);
        IDataResult<List<AllBlogsViewModel>> GetRecentBlogs();
        Task<IResult> DeleteBlogByIdAsync(string id);
		Task<IResult> EditBlog(EditBlogGet eblog);
    }
}
