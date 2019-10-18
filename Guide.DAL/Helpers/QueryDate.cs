using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Guide.DAL.Helpers
{
    public class QueryDate<T, U> where T : class
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public Expression<Func<T, U>> SortBy { get; set; }
        public Expression<Func<T, object>>[] Includes { get; set; }
        public Expression<Func<T, bool>>[] Conditions { get; set; }
    }
}
