
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
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
using Microsoft.AspNetCore.Mvc;
using MyApp.Context.Contract.CQRS.Exceptions;
using MyApp.WebApi.Contract.Results;
using AutoMapper;
using MyApp.WebApi.Mappers;

namespace MyApp.WebApi.Controllers
{
    [Route("api/product")]
    public class ProductController : BaseController
    {
        private static ILog _logger = LogManager.GetLogger(typeof(ProductController));
        private const string RouteNameGetProductById = "GetProductById";
        private const string RouteNameAddProduct = "AddProduct";
        private readonly IQueryHandler<RetrieveProductQuery, ProductDto> _retrieveProductQueryHandler;
        private readonly  ICommandHandler<AddProductCommand> _addProductCommandHandler;
        
        public ProductController(IQueryHandler<RetrieveProductQuery, ProductDto> retrieveProductQueryHandler,
            ICommandHandler<AddProductCommand> addProductCommandHandler
            )
        {
            if (retrieveProductQueryHandler == null) throw new ArgumentNullException("Retrieve product query handler cannot be passed null");
            if (addProductCommandHandler == null) throw new ArgumentNullException("Add product command handler cannot be passed null");

            _retrieveProductQueryHandler = retrieveProductQueryHandler;
            _addProductCommandHandler = addProductCommandHandler;
            
        }

        [HttpGet("{id}", Name = RouteNameGetProductById)]
        [ResponseType(typeof(ProductResponse))]
        public System.Web.Http.IHttpActionResult GetById(string id)
        {
            return null;
        }

        /// <summary>
        /// Add Product
        /// </summary>
        /// <param name="addProductRequest"></param>
        /// <returns></returns>
        [HttpPost("add", Name = RouteNameAddProduct)]
        [ResponseType(typeof(ProductResponse))]
        public IActionResult AddProduct([FromBody]AddProductRequest addProductRequest)
        {
            _logger.Info("Handling api request: create event subscription :" + addProductRequest);

            IActionResult result = null;
            try
            {
                if (RequestValidator.Validate<AddProductRequest>(Request, addProductRequest, new AddProductRequestValidator(), ref result))
                {
                    var command = AddProductRequestMapper.ToCommand(addProductRequest);
                    _addProductCommandHandler.Handle(command);

                }
            }
            catch (CommandNotValidException ex)
            {
                _logger.Warn("CommandNotValidException caught handling a AddProductCommand", ex);
                result = new BadRequest(ex.ErrorMessages.ToList(), Request);
            }
            catch (CommandTimeoutException ex)
            {
                _logger.Warn("CommandTimeoutException caught handling a AddProductCommand", ex);

                //result = new GatewayTimeout(new List<string>() { "Upstream Timeout", ex.Message },new HttpRequestMessage());
            }
            return result;
        }
    }
}