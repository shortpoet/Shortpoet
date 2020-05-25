using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Shortpoet.Data.Models.ResumeData;
using Shortpoet.Data.ResumeData.Seed;

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

          CreateDbIfNotExists(host);

          host.Run();
        }
    // adding this method to init db
    private static void CreateDbIfNotExists(IHost host)
    {
      using (var scope = host.Services.CreateScope())
      {
        var services = scope.ServiceProvider;

        try
        {
          var context = services.GetRequiredService<ResumeDbContext>();
          var hostingEnvironment = services.GetService<IWebHostEnvironment>();
          
          // run this code first before DBInit is written to test the rest of the setup
          // context.Database.EnsureCreated();


          Console.WriteLine("############################");
          Console.WriteLine("About to run CreateDbifNot Exists");
          Console.WriteLine("############################");
          Console.WriteLine("Here is connection string");
          Console.WriteLine(context.Database.GetDbConnection().ConnectionString);

          DbInitializer.InitializeDb(context, hostingEnvironment);

          context.Database.Migrate();
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
