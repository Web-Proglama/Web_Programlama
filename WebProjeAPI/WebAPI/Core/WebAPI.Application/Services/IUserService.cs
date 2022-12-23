using Microsoft.EntityFrameworkCore;
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
    public interface IUserService
    {
        Task<IResult> CreateUser(CreateUser user,string RoleName);
        Task<IResult> DeleteUser(DeleteUserDto User);
        IDataResult<UserViewModel> GetUserByUserName(string userName);
    }
}
