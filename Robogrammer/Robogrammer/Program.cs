namespace Robogrammer
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Robogrammer.Core;

    public static class Program
    {
        public static async Task Main(string[] args)
        {
            WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.ConfigureServices(builder.Configuration, builder.HostEnvironment)
                            .ConfigureCoreServices();

            await builder.Build().RunAsync();
        }
    }
}
