using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.CQRS.Queries
{
    /// <summary>
    /// Handle queries
    /// </summary>
    /// <typeparam name="TQuery"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface IQueryHandler<TQuery,TResult>
    {
        /// <summary>
        /// Handles queries
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        TResult Handle(TQuery query);
    }
}
