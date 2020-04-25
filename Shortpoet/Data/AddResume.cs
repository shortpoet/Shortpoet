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
  public class AddResume
  {
    public static void Seed(ResumeDbContext context, IWebHostEnvironment environment)
    {

      Boolean writeJson = false;

      // string path = "Data/Seed/carlos_resume.yml";
      // Resume resume = new Resume();
      // // resume = Resume.LoadJson(path);
      // resume = Resume.LoadResume(path, writeJson);
      // // resume = Resume.YmlToResume(path);
      // context.Add(resume);
      
      if (environment.EnvironmentName == "Development")
      {
        AddItems(context, EducationJson.LoadEducations("Data/Seed/carlos_resume_educations.yml", writeJson).Educations);
        AddItems(context, JobJson.LoadJobs("Data/Seed/carlos_resume_jobs.yml", writeJson).Jobs);
        context.Add(Resume.LoadResume("Data/Seed/carlos_resume_about.yml", writeJson));
        AddItems(context, SkillJson.LoadSkills("Data/Seed/carlos_resume_skills.yml", writeJson).Skills);
        AddItems(context, SocialJson.LoadSocials("Data/Seed/carlos_resume_socials.yml", writeJson).Socials);
        AddItems(context, LanguageJson.LoadLanguages("Data/Seed/carlos_resume_languages.yml", writeJson).SpokenLanguages);
        context.SaveChanges();
        
        AddItems(context, ResumeEducationsJson.LoadResumeEducations("Data/Seed/carlos_resume_resumeeducations.yml", writeJson).ResumeEducations);
        AddItems(context, ResumeJobsJson.LoadResumeJobs("Data/Seed/carlos_resume_resumejobs.yml", writeJson).ResumeJobs);
        AddItems(context, ResumeSkillsJson.LoadResumeSkills("Data/Seed/carlos_resume_resumeskills.yml", writeJson).ResumeSkills);
        AddItems(context, ResumeSocialsJson.LoadResumeSocials("Data/Seed/carlos_resume_resumesocials.yml", writeJson).ResumeSocials);
        AddItems(context, ResumeSpokenLanguagesJson.LoadResumeSpokenLanguages("Data/Seed/carlos_resume_resumespokenlanguages.yml", writeJson).ResumeSpokenLanguages);
        context.SaveChanges();

      }
      else 
      {
        AddItems(context, EducationJson.LoadJson("Data/Seed/carlos_resume_educations.json").Educations);
        AddItems(context, JobJson.LoadJson("Data/Seed/carlos_resume_jobs.json").Jobs);
        context.Add(Resume.LoadJson("Data/Seed/carlos_resume_about.json"));
        AddItems(context, SkillJson.LoadJson("Data/Seed/carlos_resume_skills.json").Skills);
        AddItems(context, SocialJson.LoadJson("Data/Seed/carlos_resume_socials.json").Socials);
        AddItems(context, LanguageJson.LoadJson("Data/Seed/carlos_resume_languages.json").SpokenLanguages);
        context.SaveChanges();
        
        AddItems(context, ResumeEducationsJson.LoadJson("Data/Seed/carlos_resume_resumeeducations.json").ResumeEducations);
        AddItems(context, ResumeJobsJson.LoadJson("Data/Seed/carlos_resume_resumejobs.json").ResumeJobs);
        AddItems(context, ResumeSkillsJson.LoadJson("Data/Seed/carlos_resume_resumeskills.json").ResumeSkills);
        AddItems(context, ResumeSocialsJson.LoadJson("Data/Seed/carlos_resume_resumesocials.json").ResumeSocials);
        AddItems(context, ResumeSpokenLanguagesJson.LoadJson("Data/Seed/carlos_resume_resumespokenlanguages.json").ResumeSpokenLanguages);
        context.SaveChanges();

      }

      
    }
    public static void Add(ResumeDbContext context, string dateFolder)
    {

      Boolean writeJson = true;

      context.Add(Resume.LoadResume($"Data/Resumes/{dateFolder}/carlos_resume_about.yml", writeJson));
      context.SaveChanges();
      
      AddItems(context, ResumeEducationsJson.LoadResumeEducations($"Data/Resumes/{dateFolder}/carlos_resume_resumeeducations.yml", writeJson).ResumeEducations);
      AddItems(context, ResumeJobsJson.LoadResumeJobs($"Data/Resumes/{dateFolder}/carlos_resume_resumejobs.yml", writeJson).ResumeJobs);
      AddItems(context, ResumeSkillsJson.LoadResumeSkills($"Data/Resumes/{dateFolder}/carlos_resume_resumeskills.yml", writeJson).ResumeSkills);
      AddItems(context, ResumeSocialsJson.LoadResumeSocials($"Data/Resumes/{dateFolder}/carlos_resume_resumesocials.yml", writeJson).ResumeSocials);
      AddItems(context, ResumeSpokenLanguagesJson.LoadResumeSpokenLanguages($"Data/Resumes/{dateFolder}/carlos_resume_resumespokenlanguages.yml", writeJson).ResumeSpokenLanguages);
      context.SaveChanges();
      
    }

    public static void AddItems<T> (ResumeDbContext context, IList<T> list)
    {
      foreach (var item in list.Reverse())
      {
        context.Add(item);
      }
    }

    // public static void LoadEducation(ResumeDbContext context , string path, Boolean writeJson)
    // {

    //   // resume = Resume.YmlToResume(path);
    //   context.Add(resume);
    //   context.SaveChanges();
      
    // }

    
  }
}