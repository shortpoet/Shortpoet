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
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Newtonsoft.Json;

using DbConnect.Data;
using DbConnect.Data.Models.Resume;

namespace DbConnect
{
  public class ResumeService
  {
    public static void Add(ResumeDbContext context, string dateFolder)
    {
      try 
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
        
      } catch (Exception e)
      {
        Console.WriteLine("##############################");
        Console.WriteLine("Resume Add Fail");
        Console.WriteLine(e);
      }
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
