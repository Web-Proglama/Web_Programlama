using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Repositories.CommentRepo
{
    public interface ICommentReadRepository:IReadRepository<Comment>
    {
    }
}
