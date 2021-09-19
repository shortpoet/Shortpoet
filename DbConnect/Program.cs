using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Data;
using DbConnect.Data.Models.ResumeData;

using System.Collections.Generic;
using System.Linq;

namespace DbConnect
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("###################");
      Console.WriteLine("Init Query");

      var builder = new ConfigurationBuilder();
      builder
          .SetBasePath(System.Environment.CurrentDirectory)
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
      var Configuration = builder.Build();

      // string connStr = Configuration.GetConnectionString("localClient");
      string connStr = Configuration.GetConnectionString("localClientTest");
      // string connStr = Configuration.GetConnectionString("spClientTestAzure");
      // string connStr = Configuration.GetConnectionString("spClientProdAzure");

      // Console.WriteLine(connStr);

      string schema = "Profiles";
      string table = "Resumes";
      string query = $"SELECT * FROM [{schema}].[{table}]";

      // DataTable results = DbTransact.GetDataTable(connStr, query);

      // Results.ShowDataTable(results);


      string dataFolder = "d20201208";
      string resumeFolder = "r20201208";
      // string dataFolder = "d20200710";
      // string resumeFolder = "r20200710";

      ResumeService.AddResumeData(new Data.ResumeDbContext(ContextConfig.GetConfig(connStr)), dataFolder);
      // ResumeService.WriteJson(dataFolder);

      ResumeService.AddResume(new Data.ResumeDbContext(ContextConfig.GetConfig(connStr)), resumeFolder);
      // ResumeService.WriteJson(resumeFolder);

      Resume resume = DbTransact.GetLatestResume(ContextConfig.GetConfig(connStr));
      // // Results.ShowJson(resume);

      Utilities.WriteHardResume(dataFolder, resume);


    }
  }
}
