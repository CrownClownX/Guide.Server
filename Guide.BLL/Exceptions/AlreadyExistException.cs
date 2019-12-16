using System;
using System.Collections.Generic;
using System.Text;

namespace Guide.BLL.Exceptions
{
    public class AlreadyExistException : Exception
    {
        public AlreadyExistException(string message)
            : base(message)
        {

        }

        public AlreadyExistException()
        {

        }
    }
}
