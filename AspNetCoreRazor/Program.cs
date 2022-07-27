using AspNetCoreRazor.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreRazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();

            var host = CreateWebHostBuilder(args).Build(); // Build the host

            // Using -> temporal usage.
            using (var scope = host.Services.CreateScope()) // Scope of the service
            {
                var services = scope.ServiceProvider; // Bring the services
                try
                {
                    var contextSchool = services.GetRequiredService<SchoolContext>(); // Get the School Context Service
                    contextSchool.Database.EnsureCreated(); // Ensure that the DB is created
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>(); // error logging
                    logger.LogError("Something went wrong with the db: -" + ex.ToString());
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
