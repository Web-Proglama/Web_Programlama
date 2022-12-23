using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.Dtos;
using WebAPI.Application.Results;
using WebAPI.Application.ViewModels;

namespace WebAPI.Application.Services
{
    public interface ICommentService
    {

        Task<IResult> addCommentAsync(AddCommentDto commentDto);
        IDataResult<List<CommentWithImage>> GetCommentsByBlogId(string blogId);
    }

}
