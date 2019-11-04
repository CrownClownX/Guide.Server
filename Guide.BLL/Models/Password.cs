using System;
using System.Collections.Generic;
using System.Text;

namespace Guide.BLL.Models
{
    public class Password
    {
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
