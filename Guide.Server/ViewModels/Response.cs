using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guide.Api.ViewModels
{
    public class Response<T> where T : class
    {
        public Response()
        {
            IsError = false;
            ErrorMessage = null;
        }

        public T Object { get; set; }
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
    }
}
