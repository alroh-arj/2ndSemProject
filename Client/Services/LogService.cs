using System.Net.Http.Json;
using New2ndSemester.Shared;

namespace New2ndSemester.Client.Services;

public interface ILogService
{
    void Initialize(HttpClient http, IUserService userService);
    Task<Log[]> GetAllLogs();
    Task AuthenticateRecentLog();
}

public class LogService : ILogService
{
    private HttpClient _http;
    private IUserService _userService;

    public void Initialize(HttpClient http, IUserService userService)
    {
        _userService = userService;
        _http = http;
    }

    public async Task<Log[]> GetAllLogs()
    {
        return await _http.GetFromJsonAsync<Log[]>("api/logs/all") ?? new Log[] {};
    }
    
    public async Task AuthenticateRecentLog()
    {
        var _sessionUser = await _userService.GetSessionUser();
        if (_sessionUser != null)
        {
            await _http.PostAsJsonAsync("api/logs/authenticate", _sessionUser.id);
        }
    }

}
