using Microsoft.EntityFrameworkCore;
using MyApp.Context.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        IRepositoryReadOnly<TEntity> GetReadOnlyRepository<TEntity>() where TEntity : class;

        int SaveChanges();
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext Context { get; }
    }

}
