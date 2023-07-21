using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace TypedHttp.Example;

public sealed class TodoService : IDisposable
{
    private readonly HttpClient _httpClient = null!;
    private readonly ILogger<TodoService> _logger = null!;

    public TodoService(
        HttpClient httpClient,
        ILogger<TodoService> logger) =>
        (_httpClient, _logger) = (httpClient, logger);

    public async Task<string> GetUserTodosAsync(int userId)
    {
        try
        {
            // Make HTTP GET request
            // Parse JSON response deserialize into Todo type
            string todos = await _httpClient.GetStringAsync(
                $"todos?userId={userId}");

            return todos;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error getting something fun to say: {Error}", ex);
        }

        return string.Empty;
    }

    /// <summary>
    /// 該不該做，我不確定，詳細可以看
    /// https://stackoverflow.com/questions/50912160/should-httpclient-instances-created-by-httpclientfactory-be-disposed
    /// </summary>
    public void Dispose() => _httpClient?.Dispose();
}