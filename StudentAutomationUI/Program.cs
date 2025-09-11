using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace StudentAutomationUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            // Point UI HttpClient to backend API (HTTP)
            builder.Services.AddScoped(sp =>
                new HttpClient { BaseAddress = new Uri("http://localhost:5000/") });

            builder.Services.AddScoped<Services.IApiService, Services.ApiService>();
            builder.Services.AddScoped<Services.TokenService>();
            builder.Services.AddScoped<Services.AuthService>();
            builder.Services.AddScoped<Services.DataService>();

            await builder.Build().RunAsync();
        }
    }
}
