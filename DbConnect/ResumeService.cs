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

  public class ResumeService
  {

    public static void WriteJson(string dateFolder)
    {
      ResumeFiles files = new ResumeFiles(dateFolder);
      foreach (string file in files)
      {
        Utilities.YmlToJsonFile(file);
      }

    }

    public static void AddResume(ResumeDbContext context, string dateFolder)
    {
      try 
      {
        // add this check so resume doesn't get imported twice 
        if (dateFolder[0] == 'r')
        {

          ResumeFiles files = new ResumeFiles(dateFolder);

          // Utilities.LoadType<Resume>(context, $"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.Resume}", writeJson);

          if (File.Exists(files.Resume)) 
          {
            Resume resume = Utilities.SerializeYml<Resume>(files.Resume);
            context.Add(resume);
          }

          context.SaveChanges();
          
          if (File.Exists(files.ResumeEducations)) 
          {
            ResumeEducationsJson resumeEducationsJson = Utilities.SerializeYml<ResumeEducationsJson>(files.ResumeEducations);
            IList<ResumeEducations> resumeEducations = resumeEducationsJson.ResumeEducations;
            AddItemsReverse(context, resumeEducations);
          }
          if (File.Exists(files.ResumeJobs)) 
          {
            ResumeJobsJson resumeJobsJson = Utilities.SerializeYml<ResumeJobsJson>(files.ResumeJobs);
            IList<ResumeJobs> resumeJobs = resumeJobsJson.ResumeJobs;
            AddItemsReverse(context, resumeJobs);
          }
          if (File.Exists(files.ResumeSkills)) 
          {
            ResumeSkillsJson resumeSkillsJson = Utilities.SerializeYml<ResumeSkillsJson>(files.ResumeSkills);
            IList<ResumeSkills> resumeSkills = resumeSkillsJson.ResumeSkills;
            AddItemsReverse(context, resumeSkills);
          }
          if (File.Exists(files.ResumeSocials)) 
          {
            ResumeSocialsJson resumeSocialsJson = Utilities.SerializeYml<ResumeSocialsJson>(files.ResumeSocials);
            IList<ResumeSocials> resumeSocials = resumeSocialsJson.ResumeSocials;
            AddItemsReverse(context, resumeSocials);
          }
          if (File.Exists(files.ResumeSpokenLanguages)) 
          {
            ResumeSpokenLanguagesJson resumeSpokenLanguagesJson = Utilities.SerializeYml<ResumeSpokenLanguagesJson>(files.ResumeSpokenLanguages);
            IList<ResumeSpokenLanguages> resumeSpokenLanguages = resumeSpokenLanguagesJson.ResumeSpokenLanguages;
            AddItemsReverse(context, resumeSpokenLanguages);
          }
          
          context.SaveChanges();
        }

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
        if (dateFolder[0] == 'd')
        {

          ResumeFiles files = new ResumeFiles(dateFolder);

          // Utilities.LoadType<Resume>(context, files.Resume, writeJson);

          if (File.Exists(files.Resume)) 
          {
            Resume resume = Utilities.SerializeYml<Resume>(files.Resume);
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
            JobJson jobJson = Utilities.SerializeYml<JobJson>(files.Job);
            IList<Job> jobs = jobJson.Jobs;
            AddItems(context, jobs);
          }
          if (File.Exists(files.Skill)) 
          {
            SkillJson skillJson = Utilities.SerializeYml<SkillJson>(files.Skill);
            IList<Skill> skills = skillJson.Skills;
            AddItems(context, skills);
          }
          if (File.Exists(files.Social)) 
          {
            SocialJson socialJson = Utilities.SerializeYml<SocialJson>(files.Social);
            IList<Social> socials = socialJson.Socials;
            AddItems(context, socials);
          }
          if (File.Exists(files.SpokenLanguages)) 
          {
            SpokenLanguagesJson spokenLanguagesJson = Utilities.SerializeYml<SpokenLanguagesJson>(files.SpokenLanguages);
            IList<SpokenLanguages> spokenLanguages = spokenLanguagesJson.SpokenLanguages;
            AddItems(context, spokenLanguages);
          }

          context.SaveChanges();
        }
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
