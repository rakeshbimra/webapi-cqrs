using MyApp.Context.Contract.CQRS.Dtos;
using MyApp.WebApi.Contract.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.WebApi.Mappers
{
    public class AddProductDtoMapper
    {

        public static ProductResponse ToResponse(ProductDto productDto)
        {
            return new ProductResponse
            {
                Id = productDto.ProductId,
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price.ToString()
            };
        }
    }
}
