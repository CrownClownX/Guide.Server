using System;
using System.Collections.Generic;
using System.Text;

namespace Guide.BLL.Exceptions
{
    public class PasswordNotValidException : Exception
    {
        public PasswordNotValidException(string message)
            : base(message)
        {

        }

        public PasswordNotValidException()
        {

        }
    }
}
