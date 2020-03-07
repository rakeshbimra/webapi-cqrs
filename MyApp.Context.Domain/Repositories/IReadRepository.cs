using Microsoft.EntityFrameworkCore.Query;
using MyApp.Context.Domain.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyApp.Context.Domain.Repositories
{
    public interface IReadRepository<TEntity> where TEntity : class
    {

        IQueryable<TEntity> Query(string sql, params object[] parameters);

        TEntity Search(params object[] keyValues);

        TEntity Single(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true);

        IPaginate<TEntity> GetList(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            int index = 0,
            int size = 20,
            bool disableTracking = true);

        IPaginate<TResult> GetList<TResult>(Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            int index = 0,
            int size = 20,
            bool disableTracking = true) where TResult : class;
    }
}
