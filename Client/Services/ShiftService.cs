using System.Net.Http.Json;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Threading.Tasks;
using New2ndSemester.Shared;

namespace New2ndSemester.Client.Services;
public interface IShiftService
{
    void Initialize(ILocalStorageService localStorageService, ILogService logService, HttpClient http);
    Task<ExtendedShift[]> GetAllShifts();
    Task Unassign(int user_id, int shift_id);
    Task Assign(int user_id, int shift_id);
    Task<ExtendedShift> SetShift(Shift shift);
    Task DeleteShift(int shift_id);
    Task<ExtendedShift?> GetShift(int shift_id);
    Task<Location[]> GetAllLocations();

    // Task<UserShift[]> GetUserShifts(int user_id);
    // Task<UserShift[]> GetAllUserShifts();
}

public class ShiftService : IShiftService
{
    private ILocalStorageService _localStorageService;
    private HttpClient _http;
    private ILogService _logService;

    public void Initialize(ILocalStorageService localStorageService, ILogService logService, HttpClient http)
    {
        _logService = logService;
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
    
    public async Task<ExtendedShift> SetShift(Shift shift)
    {
        var response = await _http.PostAsJsonAsync("api/shift/", shift);
        await _logService.AuthenticateRecentLog();
        return await response.Content.ReadFromJsonAsync<ExtendedShift>();
    }
    
    public async Task<ExtendedShift?> GetShift(int shift_id)
    {
        return await _http.GetFromJsonAsync<ExtendedShift?>("api/shift/"+shift_id);
    }

    public async Task<Location[]> GetAllLocations()
    {
        return await _http.GetFromJsonAsync<Location[]?>("api/location/all") ?? new Location[]{};
    }

    public async Task DeleteShift(int shift_id)
    {
        await _http.DeleteAsync("api/shift/"+shift_id);
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
