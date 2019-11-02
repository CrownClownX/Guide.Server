using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guide.Api.ViewModels
{
    public class ResponseCollection<T> where T : class
    {
        public ResponseCollection()
        {
            Objects = new List<T>();
            IsError = false;
            ErrorMessage = null;
        }

        public List<T> Objects { get; set; }
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
    }
}
