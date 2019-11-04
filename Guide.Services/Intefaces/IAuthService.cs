using Guide.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guide.Services.Intefaces
{
    public interface IAuthService
    {
        Task<UserDto> SignUpPlayer(SignUpDto credentials);
        Task<UserDto> SignInUser(UserCredentialsDto credentials);
    }
}
