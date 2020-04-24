using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Shortpoet.Data;
using Shortpoet.Data.Seed;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Shortpoet
{
    public class Program
    {
        public static void Main(string[] args)
        {
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
          DbInitializer.InitializeDb(context, hostingEnvironment);
          //
          // TODO 
          // this is a temporary hack to add new resumes
          string dateFolder = "20200423";
          AddResume.Add(context, dateFolder);

          context.Database.Migrate();
        }
        catch (Exception ex)
        {
          var logger = services.GetRequiredService<ILogger<Program>>();
          logger.LogError(ex, "An error occurred creating the DB.");
        }
      }
    }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
