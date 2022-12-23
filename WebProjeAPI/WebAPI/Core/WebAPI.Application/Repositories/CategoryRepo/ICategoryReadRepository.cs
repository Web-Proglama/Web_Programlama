using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Repositories.CategoryRepo
{
    public interface ICategoryReadRepository:IReadRepository<Category>
    {
    }
}
