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
    public static void InitializeDb(ResumeDbContext context)
    {
      Console.WriteLine("############################");
      Console.WriteLine("Number of resumes in context");
      Console.WriteLine(context.Resumes.Count());
      context.Database.EnsureCreated();
      
      // Look for any dashboards.
      if (context.Resumes.Any())
      {
        return;   // DB has been seeded
      }

      AddResume.Seed(context);

      Console.WriteLine("#######################");
      Console.WriteLine("Seed Data Context Changes Saved");
    }
  }
}