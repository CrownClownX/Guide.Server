using System;
using System.Collections.Generic;
using System.Text;

namespace Guide.Services.Dtos
{
    public class NewUserDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
