using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using HosxpUi;
using HosxpUi.Layout.Providers;
using MudBlazor.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using HosxpUi.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5094/") });
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://172.16.200.202:8089/") });

// Add multiple HttpClient instances with different base URLs
builder.Services.AddHttpClient("NHSO", client =>
{
    client.BaseAddress = new Uri("http://localhost:8189/");
});

// builder.Services.AddHttpClient("BackEnd", client =>
// {
//     client.BaseAddress = new Uri("http://localhost:5094/");
// });
builder.Services.AddHttpClient("BackEnd", client =>
{
    client.BaseAddress = new Uri("http://172.16.200.202:8089/");
});
// builder.Services.AddHttpClient("HosxpApi", options =>
// {
//     options.BaseAddress = new Uri("http://localhost:5094/");
//     //options.BaseAddress = new Uri("http://172.16.200.202:8089/");
// }).AddHttpMessageHandler<CustomHttpHandler>();

builder.Services.AddHttpClient("MophApi", client =>
{
    client.BaseAddress = new Uri("http://10.134.50.175:8000/");
});

builder.Services.AddSingleton<StateContainer>();
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<CustomHttpHandler>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => 
    {
       options.LoginPath = "/login";
       options.AccessDeniedPath = "/accessdenied"; 
    });


await builder.Build().RunAsync();


