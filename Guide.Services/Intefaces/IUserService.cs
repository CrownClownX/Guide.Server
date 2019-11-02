using Guide.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guide.Services.Intefaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUsers(int itemPerPage, int page);
        Task<UserDto> GetUser(long userId);
        Task<UserDto> CreateUser(NewUserDto user);
        Task<UserDto> UpdateUser(UserDto user);
        Task DeleteUser(long userId);
    }
}
