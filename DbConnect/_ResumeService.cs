// using System.IO;
// using System.Data.OleDb;
// using System.Text;
// using System.Threading.Tasks;
// using System.Data.SqlClient;
// using System.Configuration;
// using Microsoft.SqlServer;
// using Microsoft.SqlServer.Server;
// using Microsoft.SqlServer.Management.Common;
// using Microsoft.SqlServer.Management.Smo;
// using System.Data.Common;

// using System;
// using System.Reflection;
// using System.Collections.Generic;
// using System.Linq;
// using System.Data;
// using Newtonsoft.Json;

// using DbConnect.Data;
// using DbConnect.Data.Models.ResumeData;

// namespace DbConnect
// {
//   public enum FileTypes
//   {
//     Education,
//     Jobs,
//     Skills,
//     Socials,
//     Languages,
//     About
//   }

//   public static class ResumeFileStrings
//   {
//     public const string Education = "carlos_resume_educations.yml";
//     public const string Job = "carlos_resume_jobs.yml";
//     public const string Skill = "carlos_resume_skills.yml";
//     public const string Social = "carlos_resume_socials.yml";
//     public const string SpokenLanguages = "carlos_resume_languages.yml";
//     public const string Resume = "carlos_resume_about.yml";

//   }
//   public class ResumeFiles
//   {
//     public static string[] fileArray = {
//       ResumeFileStrings.Education,
//       ResumeFileStrings.Job,
//       ResumeFileStrings.Skill,
//       ResumeFileStrings.Social,
//       ResumeFileStrings.SpokenLanguages,
//       ResumeFileStrings.Resume
//     };
  
//   }

//   public class ResumeService
//   {
//     public static void AddResume(ResumeDbContext context, string dateFolder)
//     {
//       try 
//       {
//         Boolean writeJson = true;
//         Utilities.LoadType<Resume>(context, $"Data/Models/ResumeData/Resumes/{dateFolder}/{ResumeFileStrings.Resume}", writeJson);
//         context.SaveChanges();
        
//         AddItems(context, Utilities.LoadType<ResumeEducations>(context, $"Data/Models/ResumeData/Resumes/{dateFolder}/carlos_resume_resumeeducations.yml", writeJson).ResumeEducations);
//         AddItems(context, Utilities.LoadType<ResumeJobs>(context, $"Data/Models/ResumeData/Resumes/{dateFolder}/carlos_resume_resumejobs.yml", writeJson).ResumeJobs);
//         AddItems(context, Utilities.LoadType<ResumeSkills>(context, $"Data/Models/ResumeData/Resumes/{dateFolder}/carlos_resume_resumeskills.yml", writeJson).ResumeSkills);
//         AddItems(context, Utilities.LoadType<ResumeSocials>(context, $"Data/Models/ResumeData/Resumes/{dateFolder}/carlos_resume_resumesocials.yml", writeJson).ResumeSocials);
//         AddItems(context, Utilities.LoadType<ResumeSpokenLanguages>(context, $"Data/Models/ResumeData/Resumes/{dateFolder}/carlos_resume_resumespokenlanguages.yml", writeJson).ResumeSpokenLanguages);
//         context.SaveChanges();
        
//       } catch (Exception e)
//       {
//         Console.WriteLine("##############################");
//         Console.WriteLine("Resume Add Fail");
//         Console.WriteLine(e);
//       }
//     }

//     public static void AddResumeData(ResumeDbContext context, string dateFolder)
//     {
//       try 
//       {


//         Boolean writeJson = true;

//         Utilities.LoadType<Education>(context, $"Data/Models/ResumeData/Resumes/{dateFolder}/{ResumeFileStrings.Education}", writeJson)
//         Utilities.LoadType<Resume>(context, $"Data/Models/ResumeData/Resumes/{dateFolder}/{ResumeFileStrings.Resume}", writeJson)
//         Utilities.LoadType<Education>(context, $"Data/Models/ResumeData/Resumes/{dateFolder}/{ResumeFileStrings.Education}", writeJson)
//         Utilities.LoadType<Education>(context, $"Data/Models/ResumeData/Resumes/{dateFolder}/{ResumeFileStrings.Education}", writeJson)
//         Utilities.LoadType<Education>(context, $"Data/Models/ResumeData/Resumes/{dateFolder}/{ResumeFileStrings.Education}", writeJson)
//         Utilities.LoadType<Education>(context, $"Data/Models/ResumeData/Resumes/{dateFolder}/{ResumeFileStrings.Education}", writeJson)

//         context.SaveChanges();

//       } 

//       catch (Exception e)
//       {
//         Console.WriteLine("##############################");
//         Console.WriteLine("Resume Data Add Fail");
//         Console.WriteLine(e);
//       }

//     }

//     public static void AddItems<T> (ResumeDbContext context, IList<T> list)
//     {
//       foreach (var item in list.Reverse())
//       {
//         context.Add(item);
//       }
//     }

//   }
// }
