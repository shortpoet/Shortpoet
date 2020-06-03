using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Shortpoet.Data.Models.ResumeData;

namespace Shortpoet
{
    public class Program
    {
        public static void Main(string[] args)
        {
          // https://andrewlock.net/how-to-set-the-hosting-environment-in-asp-net-core/

          // var config = new ConfigurationBuilder()
          //   .AddCommandLine(args)
          //   .Build();

          // var host = CreateHostBuilder(args, config)
          var host = CreateHostBuilder(args)
            .Build();

          LogEnvData(host);

          host.Run();
        }
    // adding this method to init db
    private static void LogEnvData(IHost host)
    {
      using (var scope = host.Services.CreateScope())
      {
        var services = scope.ServiceProvider;

        try
        {
          var context = services.GetRequiredService<ResumeDbContext>();
          var hostingEnvironment = services.GetService<IWebHostEnvironment>();

          Console.WriteLine("############################");
          Console.WriteLine(hostingEnvironment.EnvironmentName);
          Console.WriteLine("############################");
          Console.WriteLine(hostingEnvironment.ContentRootPath);
          Console.WriteLine("############################");
          Console.WriteLine(hostingEnvironment.WebRootPath);
          Console.WriteLine("############################");

        }
        catch (Exception ex)
        {
          var logger = services.GetRequiredService<ILogger<Program>>();
          logger.LogError(ex, "An error occurred creating the DB.");
        }
      }
    }

        // public static IHostBuilder CreateHostBuilder(string[] args, IConfiguration config) =>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                      // .UseConfiguration(config)
                      .UseStartup<Startup>();
                });
    }
}
