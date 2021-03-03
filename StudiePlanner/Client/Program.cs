using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StudiePlanner.Client.Services;
using StudiePlanner.Shared.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StudiePlanner.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddSingleton<NotificationService>();
            builder.Services.AddHttpClient("StudiePlanner.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("StudiePlanner.ServerAPI"));
            builder.Services.AddHttpClient<IJobDataService, JobDataService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44358");
            });
            //builder.Services.AddHttpClient<INotificationService, NotificationService>(client =>
            //{
            //    client.BaseAddress = new Uri("https://localhost:44358");
            //});
            builder.Services.AddHttpClient<IAppointmentDataService, AppointmentDataService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44358");
            });
            
            builder.Services.AddApiAuthorization();

            await builder.Build().RunAsync();
        }
    }
}
