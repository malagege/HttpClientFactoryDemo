using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
        private readonly IConfiguration _configuration = null!;
        private readonly ILogger<HttpClientDemo> _logger = null!;



        public HttpClientDemo(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            ILogger<HttpClientDemo> logger) =>
            (_httpClientFactory, _configuration, _logger) =
                (httpClientFactory, configuration, logger);


        /// <summary>
        /// 使用 Named Client
        /// 一樣需要注入 factory 使用 CreateClient 放置你設定名稱就可以使用
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> GetUserTodosAsync(int userId)
        {
            // Create the client
            string? httpClientName = _configuration["TodoHttpClientName"];
            using HttpClient client = _httpClientFactory.CreateClient(httpClientName ?? "");

            try
            {
                // Make HTTP GET request
                // Parse JSON response deserialize into Todo type
                string todos = await client.GetStringAsync(
                    $"todos?userId={userId}");

                return todos;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting something fun to say: {Error}", ex);
            }

            return "";
        }

    }
}