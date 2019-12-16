using System;
using System.Collections.Generic;
using System.Text;

namespace Guide.BLL.Exceptions
{
    public class ModelNotValidException : Exception
    {
        public ModelNotValidException(string message)
            : base(message)
        {

        }

        public ModelNotValidException()
        {

        }
    }
}
