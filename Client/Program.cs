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

var app = builder.Build();

var localModelService = app.Services.GetRequiredService<IUserService>();

var localStorageService = app.Services.GetRequiredService<ILocalStorageService>();
var http = app.Services.GetRequiredService<HttpClient>();

localModelService.Initialize(localStorageService, http);

await app.RunAsync();
