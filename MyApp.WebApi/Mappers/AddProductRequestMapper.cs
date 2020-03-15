using MyApp.Context.Contract.CQRS.Commands;
using MyApp.WebApi.Contract.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.WebApi.Mappers
{
    public class AddProductRequestMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="addProductRequest"></param>
        /// <returns></returns>
        public static AddProductCommand ToCommand(AddProductRequest addProductRequest)
        {
            return new AddProductCommand
            {
                Name = addProductRequest.Name,
                Description = addProductRequest.Description,
                Price = addProductRequest.Price
            };
        }
    }
}
