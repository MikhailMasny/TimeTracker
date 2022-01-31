using Masny.TimeTracker.BlazorWebApp.Client.Interfaces;
using Masny.TimeTracker.BlazorWebApp.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Masny.TimeTracker.BlazorWebApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services
                .AddScoped<IAuthenticationService, AuthenticationService>()
                .AddScoped<IProjectService, ProjectService>()
                .AddScoped<IRecordService, RecordService>()
                .AddScoped<IHttpService, HttpService>()
                .AddScoped<ILocalStorageService, LocalStorageService>();

            builder.Services.AddScoped(x =>
            {
                var apiUrl = new Uri("https://localhost:44327");

                return new HttpClient() { BaseAddress = apiUrl };
            });

            await builder.Build().RunAsync();
        }
    }
}
