using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.Repositories.BlogRepo;
using WebAPI.Application.Repositories.CategoryRepo;
using WebAPI.Application.Repositories.CommentRepo;
using WebAPI.Application.Repositories.RoleRepo;

using WebAPI.Application.Repositories.UserRepo;
using WebAPI.Application.Services;
using WebAPI.Persistence.Contexts;
using WebAPI.Persistence.Repositories.BlogRepo;
using WebAPI.Persistence.Repositories.CategoryRepo;
using WebAPI.Persistence.Repositories.CommentRepo;
using WebAPI.Persistence.Repositories.RoleRepo;

using WebAPI.Persistence.Repositories.UserRepo;
using WebAPI.Persistence.ServicesConcrete;

namespace WebAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection service)
        {
            service.AddDbContext<WebApiDbContext>(option=>option.UseSqlServer(Configuration.ConnectionString));
            //blog repo
            service.AddScoped<IBlogReadRepository, BlogReadRepository>();
            service.AddScoped<IBlogWriteRepository, BlogWriteRepository>();
            //category repo
            service.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            service.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            //role repo
            service.AddScoped<IRoleReadRepository, RoleReadRepository>();
            service.AddScoped<IRoleWriteRepository, RoleWriteRepository>();
            //user repo
            service.AddScoped<IUserReadRepository, UserReadRepository>();
            service.AddScoped<IUserWriteRepository, UserWriteRepository>();
            //comment repo
            service.AddScoped<ICommentReadRepository, CommentReadRepository>();
            service.AddScoped<ICommentWriteRepository, CommentWriteRepository>();

           
            //blog service
            service.AddScoped<IBlogService, BlogService>();
            //category service
            service.AddScoped<ICategoryService, CategoryService>();
            //user service
            service.AddScoped<IUserService, UserService>();
            //comment service
            service.AddScoped<ICommentService, CommentService>();
            //role service
            service.AddScoped<IRoleService, RoleService>();
            
        }
    }
}
