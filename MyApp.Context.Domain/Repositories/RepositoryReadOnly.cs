using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.Domain.Repositories
{
    public class RepositoryReadOnly<T> : BaseRepository<T>, IRepositoryReadOnly<T> where T : class
    {
        public RepositoryReadOnly(DbContext context) : base(context)
        {
        }
    }
}
