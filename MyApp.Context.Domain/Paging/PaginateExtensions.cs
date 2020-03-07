using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.Domain.Paging
{
    public static class PaginateExtensions
    {
        public static IPaginate<TEntity> ToPaginate<TEntity>(this IEnumerable<TEntity> source, int index, int size, int from = 0)
        {
            return new Paginate<TEntity>(source, index, size, from);
        }

        public static IPaginate<TResult> ToPaginate<TSource, TResult>(this IEnumerable<TSource> source,
            Func<IEnumerable<TSource>, IEnumerable<TResult>> converter, int index, int size, int from = 0)
        {
            return new Paginate<TSource, TResult>(source, converter, index, size, from);
        }
    }
}
