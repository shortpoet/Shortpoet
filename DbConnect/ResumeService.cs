using System.IO;
using System.Data.OleDb;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.SqlServer;
using Microsoft.SqlServer.Server;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Data.Common;

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Newtonsoft.Json;

using DbConnect.Data;
using DbConnect.Data.Models.ResumeData;

namespace DbConnect
{
  public enum FileTypes
  {
    Education,
    Jobs,
    Skills,
    Socials,
    Languages,
    About
  }

  public static class ResumeFileStrings
  {
    public const string ProjectRoot = "Data/Models/ResumeData/Resumes";
    public const string Resume = "carlos_resume_about.yml";
    public const string Education = "carlos_resume_educations.yml";
    public const string Job = "carlos_resume_jobs.yml";
    public const string Skill = "carlos_resume_skills.yml";
    public const string Social = "carlos_resume_socials.yml";
    public const string SpokenLanguages = "carlos_resume_languages.yml";
    public const string ResumeEducations = "carlos_resume_resumeeducations.yml";
    public const string ResumeJobs = "carlos_resume_resumejobs.yml";
    public const string ResumeSkills = "carlos_resume_resumeskills.yml";
    public const string ResumeSocials = "carlos_resume_resumesocials.yml";
    public const string ResumeSpokenLanguages = "carlos_resume_resumelanguages.yml";


  }
  public class ResumeFiles
  {
    public ResumeFiles(string dateFolder)
    {
      Resume = $"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.Resume}";
      Education = $"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.Education}";
      Job = $"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.Job}";
      Skill = $"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.Skill}";
      SpokenLanguages = $"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.SpokenLanguages}";
      ResumeEducations = $"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.ResumeEducations}";
      ResumeJobs = $"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.ResumeJobs}";
      ResumeSkills = $"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.ResumeSkills}";
      ResumeSocials = $"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.ResumeSocials}";
      ResumeSpokenLanguages = $"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.ResumeSpokenLanguages}";
    }
    public string Resume { get; set; }
    public string Education { get; set; }
    public string Job { get; set; }
    public string Skill { get; set; }
    public string Social { get; set; }
    public string SpokenLanguages { get; set; }
    public string ResumeEducations { get; set; }
    public string ResumeJobs { get; set; }
    public string ResumeSkills { get; set; }
    public string ResumeSocials { get; set; }
    public string ResumeSpokenLanguages { get; set; }
    public static string[] fileArray = {
      ResumeFileStrings.ProjectRoot,
      ResumeFileStrings.Resume,
      ResumeFileStrings.Education,
      ResumeFileStrings.Job,
      ResumeFileStrings.Skill,
      ResumeFileStrings.Social,
      ResumeFileStrings.SpokenLanguages,
      ResumeFileStrings.ResumeEducations,
      ResumeFileStrings.ResumeJobs,
      ResumeFileStrings.ResumeSkills,
      ResumeFileStrings.ResumeSocials,
      ResumeFileStrings.ResumeSpokenLanguages
    };
  
  }

  public class ResumeService
  {
    public static void AddResume(ResumeDbContext context, string dateFolder)
    {
      try 
      {
        
        ResumeFiles files = new ResumeFiles(dateFolder);

        // Utilities.LoadType<Resume>(context, $"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.Resume}", writeJson);

        if (File.Exists(files.Resume)) 
        {
          Resume resume = Utilities.SerializeYml<Resume>(files.Education);
          context.Add(resume);
        }

        context.SaveChanges();
        
        if (File.Exists(files.Education)) 
        {
          EducationJson educationJson = Utilities.SerializeYml<EducationJson>(files.Education);
          IList<Education> educations = educationJson.Educations;
          AddItems(context, educations);
        }



        AddItemsReverse(context, ResumeEducationsJson.LoadType($"Data/Resumes/{dateFolder}/carlos_resume_resumeeducations.yml", writeJson).ResumeEducations);
        AddItemsReverse(context, ResumeJobsJson.LoadType($"Data/Resumes/{dateFolder}/carlos_resume_resumejobs.yml", writeJson).ResumeJobs);
        AddItemsReverse(context, ResumeSkillsJson.LoadType($"Data/Resumes/{dateFolder}/carlos_resume_resumeskills.yml", writeJson).ResumeSkills);
        AddItemsReverse(context, ResumeSocialsJson.LoadType($"Data/Resumes/{dateFolder}/carlos_resume_resumesocials.yml", writeJson).ResumeSocials);
        AddItemsReverse(context, ResumeSpokenLanguagesJson.LoadType($"Data/Resumes/{dateFolder}/carlos_resume_resumespokenlanguages.yml", writeJson).ResumeSpokenLanguages);        context.SaveChanges();
        
        context.SaveChanges();

      } catch (Exception e)
      {
        Console.WriteLine("##############################");
        Console.WriteLine("Resume Add Fail");
        Console.WriteLine(e);
      }
    }

    public static void AddResumeData(ResumeDbContext context, string dateFolder)
    {
      try 
      {

        ResumeFiles files = new ResumeFiles(dateFolder);

        // Utilities.LoadType<Resume>(context, files.Resume, writeJson);

        if (File.Exists(files.Resume)) 
        {
          Resume resume = Utilities.SerializeYml<Resume>(files.Education);
          context.Add(resume);
        }

        if (File.Exists(files.Education)) 
        {
          EducationJson educationJson = Utilities.SerializeYml<EducationJson>(files.Education);
          IList<Education> educations = educationJson.Educations;
          AddItems(context, educations);
        }
        if (File.Exists(files.Job)) 
        {
          JobJson jobJson = Utilities.SerializeYml<JobJson>($"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.Job}");
          IList<Job> jobs = jobJson.Jobs;
          AddItems(context, jobs);
        }
        if (File.Exists(files.Skill)) 
        {
          SkillJson skillJson = Utilities.SerializeYml<SkillJson>($"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.Skill}");
          IList<Skill> skills = skillJson.Skills;
          AddItems(context, skills);
        }
        if (File.Exists(files.Social)) 
        {
          SocialJson socialJson = Utilities.SerializeYml<SocialJson>($"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.Social}");
          IList<Social> socials = socialJson.Socials;
          AddItems(context, socials);
        }
        if (File.Exists(files.SpokenLanguages)) 
        {
          SpokenLanguagesJson spokenLanguagesJson = Utilities.SerializeYml<SpokenLanguagesJson>($"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.SpokenLanguages}");   
          IList<SpokenLanguages> spokenLanguages = spokenLanguagesJson.SpokenLanguages;
          AddItems(context, spokenLanguages);
        }

        context.SaveChanges();

      }  

      catch (Exception e)
      {
        Console.WriteLine("##############################");
        Console.WriteLine("Resume Data Add Fail");
        Console.WriteLine(e);
      }

    }

    public static void AddItems<T> (ResumeDbContext context, IList<T> list)
    {
      foreach (var item in list)
      {
        context.Add(item);
      }
    }
    public static void AddItemsReverse<T> (ResumeDbContext context, IList<T> list)
    {
      foreach (var item in list.Reverse())
      {
        context.Add(item);
      }
    }

  }
}
