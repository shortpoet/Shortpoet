using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Shortpoet.Data.Models.Resume;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using YamlDotNet.Serialization;

namespace Shortpoet.Data
{
  public class _AddResume
  {
    public static void Seed(ResumeDbContext context , string path, Boolean writeJson)
    {

      Resume resume = new Resume();
      // resume = Resume.LoadJson(path);
      resume = Resume.LoadResume(path, writeJson);
      // resume = Resume.YmlToResume(path);

      context.Database.OpenConnection();
      // foreach (var x in resume.SpokenLanguages.Reverse()) { 
      //   context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Profiles.SpokenLanguages ON");
      //   context.SpokenLanguages.Add(x); 
      //   context.SaveChanges();
      //   context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Profiles.SpokenLanguages OFF");
      //   }
      // foreach (var x in resume.Skills.Reverse()) { 
      //   context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Profiles.Skills ON");
      //   context.Skills.Add(x); 
      //   context.SaveChanges();
      //   context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Profiles.Skills OFF");
      //   }
      // foreach (var x in resume.Educations.Reverse()) { 
      //   context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Profiles.Educations ON");
      //   context.Educations.Add(x); 
      //   context.SaveChanges();
      //   context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Profiles.Educations OFF");
      //   }
      // foreach (var x in resume.Experiences.Reverse()){
      //   foreach (var y in x.Jobs.Reverse()) {
      //     context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Profiles.Jobs ON");
      //     context.Jobs.Add(y);
      //     context.SaveChanges();
      //     context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Profiles.Jobs OFF");
      //   }
      //   context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Profiles.Experiences ON");
      //   context.Experiences.Add(x);
      //   context.SaveChanges();
      //   context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Profiles.Experiences OFF");
      // }
      // context.Database.CloseConnection();
      // context.Add(resume);
      // context.SaveChanges();

      // // writing this to be able to load the jobs before the resume and avoid null entry
      // foreach (var experience in resume.Experiences)
      // {
      //   foreach (var job in experience.Jobs)
      //   {
      //     // ####
      //     // ## try this
      //     // ## https://stackoverflow.com/questions/5212751/how-can-i-get-id-of-inserted-entity-in-entity-framework
      //     // ####
      //     context.Entry(job).Property("ResumeId").CurrentValue = context.Resumes.Where(r => r.Title == resume.Title).First().Id;
      //   }
      // }

      // context.Entry(resume).State = EntityState.Modified;
      context.SaveChanges();
    }
    public static void Add(ResumeDbContext context , string path, Boolean writeJson)
    {

      Resume resume = new Resume();
      // resume = Resume.LoadJson(path);
      resume = Resume.LoadResume(path, writeJson);
      // resume = Resume.YmlToResume(path);

      context.Add(resume);
      context.SaveChanges();

      // writing this to be able to load the jobs before the resume and avoid null entry
      // foreach (var experience in resume.Experiences)
      // {
      //   foreach (var job in experience.Jobs)
      //   {
      //     // ####
      //     // ## try this
      //     // ## https://stackoverflow.com/questions/5212751/how-can-i-get-id-of-inserted-entity-in-entity-framework
      //     // ####
      //     context.Entry(job).Property("ResumeId").CurrentValue = context.Resumes.Where(r => r.Title == resume.Title).First().Id;
      //   }
      // }

      // context.Entry(resume).State = EntityState.Modified;
      context.SaveChanges();
    }
  }
}