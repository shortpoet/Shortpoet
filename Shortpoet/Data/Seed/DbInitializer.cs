using System;
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
      if (environment.EnvironmentName == "Development")
      {
        string path = @"Data\Seed\carlos_resume.json";
        // string path = @".\Data\Seed\public.json";
         resume = Resume.LoadJson(path);
      }
      else 
      {
        string path = "Data/Seed/carlos_resume.json";
        // string path = @".\Data\Seed\public.json";
        resume = Resume.LoadJson(path);
      }
      
      // these 3 lines ensure entities load in context in correct order 
      // when just adding resume the order in resume object was correct but ids assigned in different order
      // var ls = new List<SpokenLanguages>();
      // var ss = new List<Skill>();
      // var eds = new List<Education>();
      // var exs = new List<Experience>();
      foreach (var x in resume.SpokenLanguages.Reverse()) { 
        context.SpokenLanguages.Add(x); 
        // ls.Add(x); 
        }
      foreach (var x in resume.Skills.Reverse()) { 
        context.Skills.Add(x); 
        // ss.Add(x); 
        }
      foreach (var x in resume.Educations.Reverse()) { 
        context.Educations.Add(x); 
        // eds.Add(x); 
        }
      foreach (var x in resume.Experiences.Reverse()){
        // var jobs = new List<Job>();
        foreach (var y in x.Jobs.Reverse()) {
          // var job = new Job {
          //   Position = y.Position,
          //   Company = y.Company,
          //   Description = y.Description,
          //   StartDate = y.StartDate,
          //   EndDate = y.EndDate
          // };
          // jobs.Add(job);
          context.Jobs.Add(y);
        }
        context.Experiences.Add(x);
        // var experience = new Experience{
        //   Type = x.Type,
        //   Jobs = jobs
        // };
        // experiences.Add(experience);
        // context.Experiences.Add(experience);
        // exs.Add(experience);
      }
      // var _resume = new Resume {
      //   Title = resume.Title,
      //   Name = resume.Name,
      //   Surname = resume.Surname,
      //   Address = resume.Address,
      //   Email = resume.Email,
      //   AboutMe = resume.AboutMe,
      //   Interests = resume.Interests,
      //   Experiences = exs,
      //   Educations = eds,
      //   Skills = ss,
      //   SpokenLanguages = ls
      // };
      context.Add(resume);
      context.SaveChanges();

      // writing this to be able to load the jobs before the resume and avoid null entry
      // var experiences = new List<Experience>();
      foreach (var experience in resume.Experiences)
      {
        // var _experience = new Experience();
        // var jobs = new List<Job>();
        foreach (var job in experience.Jobs)
        {
          // var _job = new Job();
          // _job = job;
          // context.Jobs.Add(_job);
          // jobs.Add(_job);
          // ####
          // ## try this
          // ## https://stackoverflow.com/questions/5212751/how-can-i-get-id-of-inserted-entity-in-entity-framework
          // ####
          context.Entry(job).Property("ResumeId").CurrentValue = context.Resumes.Where(r => r.Title == resume.Title).First().ResumeId;
        }
        // _experience = experience;
        // context.Experiences.Add(_experience);
        // experiences.Add(_experience);
      }

      // context.Entry(resume).State = EntityState.Modified;
      context.SaveChanges();
      Console.WriteLine("#######################");
      Console.WriteLine("Seed Data Context Changes Saved");
    }
  }
}