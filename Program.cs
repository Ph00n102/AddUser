using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using HosxpUi;
using HosxpUi.Layout.Providers;
using MudBlazor.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using HosxpUi.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5094/") });

// builder.Services.AddHttpClient("HosxpApi", client => 
// {
//     client.BaseAddress = new Uri("http://localhost:5094/");
// });

// builder.Services.AddHttpClient("HosxpApi", options =>
// {
//     options.BaseAddress = new Uri("http://localhost:5094/");
// }).AddHttpMessageHandler<CustomHttpHandler>();

builder.Services.AddSingleton<StateContainer>();
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<CustomHttpHandler>();

await builder.Build().RunAsync();
