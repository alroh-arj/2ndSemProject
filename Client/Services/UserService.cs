using System.Net.Http.Json;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Threading.Tasks;
using New2ndSemester.Shared;

namespace New2ndSemester.Client.Services;
public interface IUserService
{
    void Initialize(ILocalStorageService localStorageService, HttpClient http);
    Task<User?> GetSessionUser();
    Task SetSessionUser(User user);
    Task RemoveSessionUser();
    Task<Role[]> GetSessionUserRoles();
    Task<bool> SessionUserHasRole(string role_name);
    Task<bool> UserHasRole(int user_id, string role_name);
    Task<User?> GetUser(int user_id);
    Task<Role[]> GetUserRoles(int user_id);
    Task DeleteUser(int user_id);
    Task UpdateUser(User user);
    Task AddRole(int user_id, int role_id);
    Task RemoveRole(int user_id, int role_id);
}

public class UserService : IUserService
{
    private ILocalStorageService _localStorageService;
    private HttpClient _http;
    // public event EventHandler<User?> _onUserChanged;
    
    // public void OnUserChanged(Delegate callback)
    // {
    //     _onUserChanged += callback;
    // }
    public void Initialize(ILocalStorageService localStorageService, HttpClient http)
    {
        _localStorageService = localStorageService;
        _http = http;
    }
    
    public async Task<User?> GetSessionUser()
    {
        return await _localStorageService.GetItem<User?>("user");
    }
    
    public async Task SetSessionUser(User user)
    {
        await _localStorageService.SetItem("user", user);
    }
    
    public async Task<Role[]> GetSessionUserRoles()
    {
        var sessionUser = await GetSessionUser();
        return await GetUserRoles(sessionUser.id);
    }
    
    public async Task<bool> SessionUserHasRole(string role_name)
    {
        var sessionUserRoles = await GetSessionUserRoles();
        var roleNames = sessionUserRoles.Select(role => role.name);
        return roleNames.Contains(role_name);
    }

    public async Task RemoveSessionUser()
    {
        await _localStorageService.RemoveItem("user");
    }

    public async Task<User?> GetUser(int user_id)
    {
        return await _http.GetFromJsonAsync<User>("api/user/" + user_id);
    }
    
    public async Task<Role[]> GetUserRoles(int user_id)
    {
        return await _http.GetFromJsonAsync<Role[]>("api/user/" + user_id + "/roles") ?? new Role[] {};
    }
    
    public async Task<bool> UserHasRole(int user_id, string role_name)
    {
        var sessionUserRoles = await GetUserRoles(user_id);
        var roleNames = sessionUserRoles.Select(role => role.name);
        return roleNames.Contains(role_name);
    }
    
    public async Task DeleteUser(int user_id)
    {
        var response = await _http.DeleteAsync("api/user/" + user_id);
        
        if (response.IsSuccessStatusCode)
        {
            var sessionUser = await GetSessionUser();
            if (sessionUser != null && sessionUser.id == user_id)
                await RemoveSessionUser();
        } else {
            throw new Exception(await response.Content.ReadAsStringAsync());
        }
    }

    public async Task UpdateUser(User user)
    {
        var response = await _http.PostAsJsonAsync("api/user/"+user.id+"/update", user);
        
        if (response.IsSuccessStatusCode)
        {
            var sessionUser = await GetSessionUser();
            if (sessionUser != null && sessionUser.id == user.id)
                await SetSessionUser(user);
        }
        else
        {
            throw new Exception(await response.Content.ReadAsStringAsync());
        }
    }

    public async Task AddRole(int user_id, int role_id)
    {
        await _http.PostAsJsonAsync("api/user/"+user_id+"/roles", role_id);
    }
    
    public async Task RemoveRole(int user_id, int role_id)
    {
        await _http.DeleteAsync("api/user/"+user_id+"/roles/"+role_id);
    }
}
