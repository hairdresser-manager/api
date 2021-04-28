using System;
using System.Threading;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .Build();

            var host = CreateHostBuilder(args).Build();
            ILogger logger = host.Services.GetService<ILogger<Program>>();
            
            try
            {
                logger.LogInformation("Application starting up");
                
                ApplyMigrations(host, logger);

                logger.LogInformation("Application is ready to rock");
                
                host.Run();
            }
            catch (Exception e)
            {
                logger.LogInformation($"{e} The application failed to start");
            }
        }

        private static void ApplyMigrations(IHost host, ILogger logger)
        {
            logger.LogInformation("Trying to apply migrations into database");
            
            bool dbReadyToGo;
            do
            {
                try
                {
                    using (var scope = host.Services.CreateScope())
                    {
                        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                        db.Database.Migrate();
                    }

                    dbReadyToGo = true;
                }
                catch (Exception e)
                {
                    dbReadyToGo = false;
                    logger.LogError(e , "Something went wrong while applying migrations");
                    logger.LogInformation("Trying again after 6 seconds");
                    Thread.Sleep(6000);
                }
            } while (dbReadyToGo == false);
            
            logger.LogInformation("Migrations applied successfully");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}