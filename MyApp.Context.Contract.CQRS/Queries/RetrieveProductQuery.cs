using MyApp.Context.Contract.CQRS.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.Contract.CQRS.Queries
{
    public class RetrieveProductQuery : IQuery<ProductDto>
    {
        public Guid ProductId { get; set; }
    }
}
