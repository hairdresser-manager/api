using System;
using System.Threading;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            try
            {
                var host = CreateHostBuilder(args).Build();
                ApplyMigrations(host);
                host.Run();
            }
            catch (Exception)
            {
                // ignored
            }

            CreateHostBuilder(args).Build().Run();
        }

        private static void ApplyMigrations(IHost host)
        {
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
                catch (Exception)
                {
                    dbReadyToGo = false;
                    Thread.Sleep(6000);
                }
            } while (dbReadyToGo == false);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}