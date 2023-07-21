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

        /// <summary>
        /// 基本使用 HttpClientFactory
        /// </summary>
        /// <param name="httpClientFactory"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<string?> NormalUse()
        {
            // Create the client
            using HttpClient client = _httpClientFactory.CreateClient();
            string? result = null;
            try
            {
                // Make HTTP GET request
                // Parse JSON response deserialize into Todo types
                result = await client.GetStringAsync("http://localhost:5118/swagger/");

                return result ;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting something fun to say: {Error}", ex);
            }

            return result;
        }
    }
}