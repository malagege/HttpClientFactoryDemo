using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace HttpClientFactoryDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HttpClientDemo : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory = null!;
        private readonly ILogger<HttpClientDemo> _logger = null!;



        public HttpClientDemo(
            IHttpClientFactory httpClientFactory,
            ILogger<HttpClientDemo> logger) =>
            (_httpClientFactory, _logger) = (httpClientFactory, logger);


    }
}