using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Shortpoet.Data.Models.ResumeData;
using Shortpoet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;


namespace Shortpoet.Data.ResumeData.Seed
{
  public class DbInitializer
  {
    public static void InitializeDb(ResumeDbContext context, IWebHostEnvironment environment)
    {
      Console.WriteLine("############################");
      Console.WriteLine(environment.EnvironmentName);
      Console.WriteLine("############################");
      Console.WriteLine(environment.ContentRootPath);
      Console.WriteLine("############################");
      Console.WriteLine(environment.WebRootPath);
      Console.WriteLine("############################");
      Console.WriteLine("Number of resumes in context");
      Console.WriteLine(context.Resumes.Count());
      
      // COMMENT THIS IS PRODUCTION OR EVEN REMOVE
      // context.Database.EnsureCreated();
      
      // Look for any dashboards.
      if (context.Resumes.Any())
      {
        return;   // DB has been seeded
      }

      AddResume.Seed(context, environment);

      Console.WriteLine("#######################");
      Console.WriteLine("Seed Data Context Changes Saved");
    }
  }
}