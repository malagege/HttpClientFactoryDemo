using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpClientFactoryDemo.Shared;
using Refit;

namespace HttpClientFactoryDemo.Services
{
    public interface ITodoService
    {
        [Get("/todos?userId={userId}")]
        Task<Todo[]> GetUserTodosAsync(int userId);
    }
}