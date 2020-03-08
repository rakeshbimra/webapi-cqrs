using log4net;
using MyApp.WebApi.Contract.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace MyApp.WebApi.Contract
{
    public class RequestValidator : IRequestValidator
    {
        protected static ILog _logger = LogManager.GetLogger(typeof(RequestValidator));

        public bool Validate<T>(HttpRequestMessage httpRequest, T request, FluentValidation.IValidator<T> validator, ref IHttpActionResult invalidResult) where T : class
        {
            bool result = false;


            if (request == null)
            {
                _logger.Warn(typeof(T).FullName + " was passed null, request must contain data. Throwing ValidationException");

                invalidResult = new BadRequest(new List<string>() { "Request must contain data" }, httpRequest);
            }
            else
            {
                var validationResult = validator.Validate(request);

                if (!validationResult.IsValid)
                {
                    invalidResult = new BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).ToList(), httpRequest);

                    string errors = string.Join(";", validationResult.Errors);

                    _logger.Warn(typeof(T).FullName + " failed validation, request invalid.");
                }
                else
                {
                    result = true;
                }

            }

            return result;
        }
    }
}
