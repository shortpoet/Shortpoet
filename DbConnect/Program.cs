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

            string connStr = Configuration.GetConnectionString("localClientTest");
            
            Console.WriteLine(connStr);
            
            string schema = "Profiles";
            string table = "Resumes";
            string query = $"SELECT * FROM [{schema}].[{table}]";

            // DataTable results = DbTransact.GetDataTable(connStr, query);

            // Results.ShowDataTable(results);

            // Resume resume = DbTransact.GetResume(ContextConfig.GetConfig(connStr));

            // Results.ShowJson(resume);
            string dateFolder = "d20200602";

            ResumeService.AddResumeData(new Data.ResumeDbContext(ContextConfig.GetConfig(connStr)), dateFolder);
            ResumeService.AddResume(new Data.ResumeDbContext(ContextConfig.GetConfig(connStr)), dateFolder);

            ResumeService.WriteJson(dateFolder);

        }
    }
}
