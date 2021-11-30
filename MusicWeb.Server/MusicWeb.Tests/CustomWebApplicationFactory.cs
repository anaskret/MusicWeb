/*using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Tests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((hostingContext, configurationBuilder) =>
            {
                var type = typeof(TStartup);
                var path = @"C:\\OriginalApplication";

                configurationBuilder.AddJsonFile($"{path}\\appsettings.json", optional: true, reloadOnChange: true);
                configurationBuilder.AddEnvironmentVariables();
            });

            // if you want to override Physical database with in-memory database
            builder.ConfigureServices(services =>
            {
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                services.AddDbContext<ApplicationDBContext>(options =>
                {
                    options.UseInMemoryDatabase("DBInMemoryTest");
                    options.UseInternalServiceProvider(serviceProvider);
                });
            });
        }
    }
}
*/