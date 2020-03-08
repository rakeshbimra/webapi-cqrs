using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.WebApi.Contract;

namespace MyApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private static ILog _logger = LogManager.GetLogger(typeof(BaseController));
        private IRequestValidator _requestValidator;

        protected IRequestValidator RequestValidator
        {
            get
            {
                if (_requestValidator == null)
                    _requestValidator = new RequestValidator();
                return _requestValidator;
            }
        }

    }
}