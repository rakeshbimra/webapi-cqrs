
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using log4net;
using Microsoft.AspNetCore.Http;
using MyApp.Context.Contract.CQRS.Commands;
using MyApp.Context.Contract.CQRS.Dtos;
using MyApp.Context.Contract.CQRS.Queries;
using MyApp.Context.CQRS.Commands;
using MyApp.Context.CQRS.Queries;
using MyApp.WebApi.Contract.Requests;
using MyApp.WebApi.Contract.Response;
using MyApp.WebApi.RequestValidators;

namespace MyApp.WebApi.Controllers
{
    [Route("api/product")]
    public class ProductController : BaseController
    {
        public const string RouteNameGetProductById = "GetProductById";

        private static ILog _logger = LogManager.GetLogger(typeof(ProductController));

        internal IQueryHandler<RetrieveProductQuery, ProductDto> _retrieveProductQueryHandler;
        internal ICommandHandler<AddProductCommand> _addProductCommandHandler;

        public ProductController(IQueryHandler<RetrieveProductQuery, ProductDto> retrieveProductQueryHandler,
            ICommandHandler<AddProductCommand> addProductCommandHandler)
        {
            if (retrieveProductQueryHandler == null) throw new ArgumentNullException("Retrieve product query handler cannot be passed null");
            if (addProductCommandHandler == null) throw new ArgumentNullException("Add product command handler cannot be passed null");

            _retrieveProductQueryHandler = retrieveProductQueryHandler;
            _addProductCommandHandler = addProductCommandHandler;
        }

        [Route("{id}", Name = RouteNameGetProductById)]
        [HttpGet]
        [ResponseType(typeof(ProductResponse))]
        public IHttpActionResult GetById(string id)
        {
            return null;
        }

        //[HttpPost]
        //[ResponseType(typeof(ProductResponse))]
        //public IHttpActionResult AddProduct([FromBody]AddProductRequest requestData)
        //{
        //    //_logger.Info("Handling api request: create event subscription", requestData);

        //    IHttpActionResult result = null;
        //    try
        //    {
        //        //if(RequestValidator.Validate<AddProductRequest>(Request,requestData,new AddProductRequestValidator(),ref result))
        //        //{

        //        //}
        //    }
        //    catch
        //    {

        //    }
        //    return result;
        //}
    }
}