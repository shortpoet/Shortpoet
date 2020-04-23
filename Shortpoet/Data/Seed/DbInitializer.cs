using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Shortpoet.Data.Models.Resume;
using Shortpoet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;


namespace Shortpoet.Data.Seed
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

      context.Database.EnsureCreated();
      // Look for any dashboards.
      if (context.Resumes.Any())
      {
        return;   // DB has been seeded
      }

      // string path = "Data/Seed/carlos_resume.json";
      AddResume.Seed(context);

      Console.WriteLine("#######################");
      Console.WriteLine("Seed Data Context Changes Saved");
    }
  }
}