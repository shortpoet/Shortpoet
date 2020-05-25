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

    public static void AddItems<T> (ResumeDbContext context, IList<T> list)
    {
      foreach (var item in list.Reverse())
      {
        context.Add(item);
      }
    }
    
  }
}