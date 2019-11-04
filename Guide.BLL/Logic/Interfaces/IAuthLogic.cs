using Guide.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guide.BLL.Logic.Interfaces
{
    public interface IAuthLogic
    {
        string GenerateToken(long id);
        Password CreatePasswordHash(string password);
        bool VerifyPasswordHash(string password, Password encryptedPassword);
    }
}
