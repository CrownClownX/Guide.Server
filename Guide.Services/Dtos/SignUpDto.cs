using System;
using System.Collections.Generic;
using System.Text;

namespace Guide.Services.Dtos
{
    public class SignUpDto
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
