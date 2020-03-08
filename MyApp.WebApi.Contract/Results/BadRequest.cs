using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyApp.WebApi.Contract.Results
{
    public class BadRequest : IHttpActionResult
    {
        readonly Error _error;
        readonly HttpRequestMessage _request;

        public BadRequest(List<string> messages, HttpRequestMessage request)
        {
            _error = Error.CreateBadRequestError(messages);
            _request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = _request.CreateResponse<Error>((System.Net.HttpStatusCode)_error.HttpStatusCode, _error);

            return Task.FromResult(response);
        }
    }
}
