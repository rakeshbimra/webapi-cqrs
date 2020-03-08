using FluentValidation;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace MyApp.WebApi.Contract
{
    public interface IRequestValidator
    {
        /// <summary>
        /// Handles validation of requests in generic manner
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpRequest"></param>
        /// <param name="request"></param>
        /// <param name="validator"></param>
        /// <param name="invalidResult"></param>
        /// <returns></returns>
        bool Validate<T>(HttpRequestMessage httpRequest, T request, IValidator<T> validator, ref IHttpActionResult invalidResult) where T : class;
    }
}
