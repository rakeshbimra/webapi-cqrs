using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Add(params TEntity[] entities);
        void Add(IEnumerable<TEntity> entities);


        void Delete(TEntity entity);
        void Delete(object id);
        void Delete(params TEntity[] entities);
        void Delete(IEnumerable<TEntity> entities);


        void Update(TEntity entity);
        void Update(params TEntity[] entities);
        void Update(IEnumerable<TEntity> entities);
    }
}
