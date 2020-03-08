using MyApp.Context.Contract.CQRS.Dtos;
using MyApp.Context.Contract.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.CQRS.Queries
{
    public class RetrieveProductQueryHandler : IQueryHandler<RetrieveProductQuery, ProductDto>
    {
        public ProductDto Handle(RetrieveProductQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
