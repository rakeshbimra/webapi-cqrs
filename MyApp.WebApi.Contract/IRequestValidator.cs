using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        bool Validate<T>(HttpRequest httpRequest, T request, IValidator<T> validator, ref IActionResult invalidResult) where T : class;
    }
}
