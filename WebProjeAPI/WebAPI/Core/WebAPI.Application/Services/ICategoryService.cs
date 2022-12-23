using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.Dtos;
using WebAPI.Application.Results;

namespace WebAPI.Application.Services
{
    public interface ICategoryService
    {
        IDataResult<List<CategoryDto>> GetAllCategory();
    }
}
