using System;
using System.Collections.Generic;
using System.Text;

namespace Guide.BLL.Exceptions
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(string message)
            : base(message)
        {

        }

        public DataNotFoundException()
        {

        }
    }
}
