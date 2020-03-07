using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.Domain.Repositories
{
    public interface IRepositoryReadOnly<T> : IReadRepository<T> where T : class
    {

    }
}
