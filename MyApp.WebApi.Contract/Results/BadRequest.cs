using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyApp.WebApi.Contract.Results
{
    public class BadRequest : IActionResult
    {
        readonly Error _error;
        readonly HttpRequest _request;

        public BadRequest(List<string> messages, HttpRequest request)
        {
            _error = Error.CreateBadRequestError(messages);
            _request = request;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(_error)
            {
                StatusCode=_error.HttpStatusCode,
                Value=_error
            };
            await objectResult.ExecuteResultAsync(context);
        }
    }
}
