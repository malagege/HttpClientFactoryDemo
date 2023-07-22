using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HttpClientFactoryDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace HttpClientFactoryDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HttpClientDemo : ControllerBase
    {
        private readonly ITodoService _todoService = null!;
        private readonly ILogger<HttpClientDemo> _logger = null!;



        public HttpClientDemo(
            ITodoService todoService,
            ILogger<HttpClientDemo> logger) =>
            (_todoService, _logger) = (todoService, logger);


        [HttpGet]
        public async Task<Shared.Todo[]> GetUserTodosAsync(int userId)
        {
            return await _todoService.GetUserTodosAsync(userId);
        }

    }
}