using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace DbConnect.Data.Models.ResumeData.Seed
{
  public class DbInitializer
  {
    public static void InitializeDb(ResumeDbContext context)
    {      
      // COMMENT THIS IS PRODUCTION OR EVEN REMOVE
      // context.Database.EnsureCreated();
      
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