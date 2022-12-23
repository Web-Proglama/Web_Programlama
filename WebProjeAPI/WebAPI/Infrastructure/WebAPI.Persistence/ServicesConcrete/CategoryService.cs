using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.Dtos;
using WebAPI.Application.Repositories.CategoryRepo;
using WebAPI.Application.Results;
using WebAPI.Application.Services;
using WebAPI.Persistence.ResultConcrete;

namespace WebAPI.Persistence.ServicesConcrete
{
    public class CategoryService : ICategoryService
    {
        private ICategoryReadRepository _categoryReadRepository;
        private ICategoryWriteRepository _categoryWriteRepository;

        public CategoryService(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
        }

        public IDataResult<List<CategoryDto>> GetAllCategory()
        {
            var datas = (from category in _categoryReadRepository.GetAll()
                        select new CategoryDto()
                        {
                            CategoryId = category.Id,
                            CategoryName = category.CategoryName,
                            BlogCount=category.Blogs.Count,
                        }).ToList();
           return new SuccessDataResult<List<CategoryDto>>(datas);
        }
    }
}
