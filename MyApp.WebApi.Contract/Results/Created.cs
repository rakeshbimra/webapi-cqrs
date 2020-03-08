using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyApp.WebApi.Contract.Results
{
    public class Created : IHttpActionResult
    {
        readonly HttpRequestMessage _request;
        readonly string _location;

        public Created(HttpRequestMessage request, string location)
        {
            _request = request;
            _location = location;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = _request.CreateResponse(HttpStatusCode.Created);

            response.Headers.Location = new Uri(_location);

            return Task.FromResult(response);
        }
    }
}
