
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Guide.DAL.Helpers
{
    public static class LinqExtensions
    {
        public static IQueryable<T> MultipleInclude<T>(this IQueryable<T> query, Expression<Func<T, object>>[] includes) where  T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }

        public static IQueryable<T> NullableWhere<T>(this IQueryable<T> query, Expression<Func<T, bool>>[] conditions) where T : class
        {
            if (conditions != null)
            {
                query = conditions.Aggregate(query, (current, condition) => current.Where(condition));
            }

            return query;
        }

        public static IQueryable<T> NullableOrderBy<T, U>(this IQueryable<T> query, Expression<Func<T, U>> conditions) where T : class
        {
            if (conditions != null)
            {
                query = query.OrderBy(conditions);
            }

            return query;
        }
    }
}
