using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using TypedHttp.Example;

namespace HttpClientFactoryDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HttpClientDemo : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory = null!;
        private readonly ILogger<HttpClientDemo> _logger = null!;
        private readonly TodoService _todoService;

        public HttpClientDemo(
            TodoService todoService,
            IHttpClientFactory httpClientFactory,
            ILogger<HttpClientDemo> logger) =>
            (_httpClientFactory, _logger, _todoService) = (httpClientFactory, logger, todoService);


        /// <summary>
        /// Typed Client 注入
        /// 但注意!!因為裡面沒有做 CreateClient 方法，所以不能用在 Singleton 模式的類別載入 TodoService。不然就要改成 NamedClient。
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> Todo(int userId){
            return await _todoService.GetUserTodosAsync(userId);
        }
    }
}