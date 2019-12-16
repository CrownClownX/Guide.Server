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
        void VerifyPasswordHash(string password, Password encryptedPassword);
    }
}
