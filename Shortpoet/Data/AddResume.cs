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
    public static void Seed(ResumeDbContext context)
    {

      Boolean writeJson = false;

      // string path = "Data/Seed/carlos_resume.yml";
      // Resume resume = new Resume();
      // // resume = Resume.LoadJson(path);
      // resume = Resume.LoadResume(path, writeJson);
      // // resume = Resume.YmlToResume(path);
      // context.Add(resume);
      
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

    public static void AddItems<T> (ResumeDbContext context, IList<T> list)
    {
      foreach (var item in list)
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