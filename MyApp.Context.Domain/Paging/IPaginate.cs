using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.Domain.Paging
{
    public interface IPaginate<TEntity>
    {
        int From { get; }
        int Index { get; }
        int Size { get; }
        int Count { get; }
        int Pages { get; }
        IList<TEntity> Items { get; }
        bool HasPrevious { get; }
        bool HasNext { get; }
    }
}
