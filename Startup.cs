using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace SolicitacaoEntrega
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }
        public static void Configure()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public static IServiceProvider ConfigureServices() 
        {
            var services = new ServiceCollection();

            services.Add(new ServiceDescriptor(typeof(IConfiguration), Configuration));

            return services.BuildServiceProvider();
        }
    }
}
