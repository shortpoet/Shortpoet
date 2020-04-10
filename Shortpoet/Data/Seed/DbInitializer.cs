using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Shortpoet.Data.Models.Resume;
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
      Resume resume = new Resume();
      Resume _resume = new Resume();
      if (environment.EnvironmentName == "Development")
      {
        string path = @"Data\Seed\carlos_resume.json";
         resume = Resume.LoadJson(path);
      }
      else 
      {
        string path = "Data/Seed/carlos_resume.json";
        resume = Resume.LoadJson(path);
      }

      context.Database.OpenConnection();
      foreach (var x in resume.SpokenLanguages.Reverse()) { 
        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Profiles.SpokenLanguages ON");
        context.SpokenLanguages.Add(x); 
        context.SaveChanges();
        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Profiles.SpokenLanguages OFF");
        }
      foreach (var x in resume.Skills.Reverse()) { 
        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Profiles.Skills ON");
        context.Skills.Add(x); 
        context.SaveChanges();
        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Profiles.Skills OFF");
        }
      foreach (var x in resume.Educations.Reverse()) { 
        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Profiles.Educations ON");
        context.Educations.Add(x); 
        context.SaveChanges();
        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Profiles.Educations OFF");
        }
      foreach (var x in resume.Experiences.Reverse()){
        foreach (var y in x.Jobs.Reverse()) {
          context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Profiles.Jobs ON");
          context.Jobs.Add(y);
          context.SaveChanges();
          context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Profiles.Jobs OFF");
        }
        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Profiles.Experiences ON");
        context.Experiences.Add(x);
        context.SaveChanges();
        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Profiles.Experiences OFF");
      }
      context.Database.CloseConnection();
      context.Add(resume);
      context.SaveChanges();

      // writing this to be able to load the jobs before the resume and avoid null entry
      foreach (var experience in resume.Experiences)
      {
        foreach (var job in experience.Jobs)
        {
          // ####
          // ## try this
          // ## https://stackoverflow.com/questions/5212751/how-can-i-get-id-of-inserted-entity-in-entity-framework
          // ####
          context.Entry(job).Property("ResumeId").CurrentValue = context.Resumes.Where(r => r.Title == resume.Title).First().Id;
        }
      }

      // context.Entry(resume).State = EntityState.Modified;
      context.SaveChanges();
      Console.WriteLine("#######################");
      Console.WriteLine("Seed Data Context Changes Saved");
    }
  }
}