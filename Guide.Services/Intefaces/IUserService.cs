using Guide.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guide.Services.Intefaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers();
    }
}
