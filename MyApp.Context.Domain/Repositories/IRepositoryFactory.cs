using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.Domain.Repositories
{
    public interface IRepositoryFactory
    {
        IRepository<T> GetRepository<T>() where T : class;
        IRepositoryReadOnly<T> GetReadOnlyRepository<T>() where T : class;
    }
}
