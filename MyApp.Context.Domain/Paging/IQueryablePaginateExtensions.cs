using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyApp.Context.Domain.Paging
{
    public static class IQueryablePaginateExtensions
    {
        public static async Task<IPaginate<TEntity>> ToPaginateAsync<TEntity>(this IQueryable<TEntity> source, int index, int size,
            int from = 0, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (from > index) throw new ArgumentException($"From: {from} > Index: {index}, must From <= Index");

            var count = await source.CountAsync(cancellationToken).ConfigureAwait(false);
            var items = await source.Skip((index - from) * size)
                .Take(size).ToListAsync(cancellationToken).ConfigureAwait(false);

            var list = new Paginate<TEntity>
            {
                Index = index,
                Size = size,
                From = from,
                Count = count,
                Items = items,
                Pages = (int)Math.Ceiling(count / (double)size)
            };

            return list;
        }
    }
}
