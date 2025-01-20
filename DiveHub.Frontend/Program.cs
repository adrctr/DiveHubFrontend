using System;
using System.Net.Http;
using DiveHub.ClientApi.Api;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DiveHub.Frontend;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

const string apiClientBackendBasePath = "http://localhost:5109";

DiveHub.ClientApi.Client.Configuration apiClientBackendConfiguration = new()
{
    BasePath = apiClientBackendBasePath,
};

#region API CLIENT DI
builder.Services.AddScoped<IDiveApiAsync, DiveApi>();
builder.Services.AddScoped<IUserApiAsync, UserApi>();
#endregion

builder.Services.AddMudServices();

await builder.Build().RunAsync();