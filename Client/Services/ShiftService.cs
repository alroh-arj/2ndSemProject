using System.Net.Http.Json;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Threading.Tasks;
using New2ndSemester.Shared;

namespace New2ndSemester.Client.Services;
public interface IShiftService
{
    void Initialize(ILocalStorageService localStorageService, HttpClient http);
    Task<ExtendedShift[]> GetAllShifts();
    Task Unassign(int user_id, int shift_id);
    Task Assign(int user_id, int shift_id);

    // Task<UserShift[]> GetUserShifts(int user_id);
    // Task<UserShift[]> GetAllUserShifts();
}

public class ShiftService : IShiftService
{
    private ILocalStorageService _localStorageService;
    private HttpClient _http;

    public void Initialize(ILocalStorageService localStorageService, HttpClient http)
    {
        _localStorageService = localStorageService;
        _http = http;
    }

    public async Task<ExtendedShift[]> GetAllShifts()
    {
        return await _http.GetFromJsonAsync<ExtendedShift[]>("api/shift/all") ?? new ExtendedShift[] {};
    }

    public async Task Assign(int user_id, int shift_id)
    {
        await _http.PostAsJsonAsync("api/user_shift/", new UserShift {user_id = user_id, shift_id = shift_id});
    }
    
    public async Task Unassign(int user_id, int shift_id)
    {
        await _http.DeleteAsync("api/shift/"+shift_id+"/"+user_id);
    }
    // public async Task<UserShift[]> GetUserShifts(int user_id)
    // {
    //     return await _http.GetFromJsonAsync<UserShift[]>("api/user_shift/"+user_id) ?? new UserShift[] {};
    // } 
    // public async Task<UserShift[]> GetAllUserShifts()
    // {
    //     return await _http.GetFromJsonAsync<UserShift[]>("api/user_shift/all") ?? new UserShift[] {};
    // } 
}
