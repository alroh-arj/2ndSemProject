using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using New2ndSemester.Client;
using New2ndSemester.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IShiftService, ShiftService>();
builder.Services.AddScoped<ILogService, LogService>();

var app = builder.Build();

var localStorageService = app.Services.GetRequiredService<ILocalStorageService>();
var http = app.Services.GetRequiredService<HttpClient>();

var userService = app.Services.GetRequiredService<IUserService>();
var shiftService = app.Services.GetRequiredService<IShiftService>();
var logService = app.Services.GetRequiredService<ILogService>();

userService.Initialize(localStorageService, logService, http);
shiftService.Initialize(localStorageService, logService, http);
logService.Initialize(http, userService);

await app.RunAsync();
