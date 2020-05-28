using System.IO;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;
using System.Configuration;
using Microsoft.SqlServer;
using Microsoft.SqlServer.Server;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Data.Common;

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;

using DbConnect.Data.Models.ResumeData;
using DbConnect.Data;

namespace DbConnect
{
    public class DbTransact
    {
        public static DataTable GetDataTable(string connectionString, string query)
        {
            DataTable response = new DataTable();

            try 
            {
              using (SqlConnection instanceConnection = new SqlConnection(connectionString))
              {
                  instanceConnection.Open();
                  using (SqlCommand cmd = new SqlCommand(query, instanceConnection))
                  {
                      response.Load(cmd.ExecuteReader());
                      // Start a local transaction.
                      //SqlTransaction sqlTran = instanceConnection.BeginTransaction();
                      //cmd.Transaction = sqlTran;
                      //cmd.CommandText = "select COUNT(*) FROM Translations.DefensePrograms";
                      //int totalRow = Convert.ToInt32(cmd.ExecuteScalar());
                      //Console.WriteLine(totalRow);
                  }
                  instanceConnection.Close();
              }
            }
            catch (Exception e)
            {
              Console.WriteLine(e);
            }
          return response;
        }
    
      public static Resume GetResume (DbContextOptions<ResumeDbContext> options)
      {
        using (var db = new ResumeDbContext(options))
        {
          var resume = db.Resumes
            .Include(r => r.ResumeEducations)
              .ThenInclude(r => r.Education)
            .Include(r => r.ResumeJobs)
              .ThenInclude(r => r.Job)
            .Include(r => r.ResumeSkills)
              .ThenInclude(r => r.Skill)
            .Include(r => r.ResumeSocials)
              .ThenInclude(r => r.Social)
            .Include(r => r.ResumeSpokenLanguages)
              .ThenInclude(r => r.SpokenLanguages)
            .AsNoTracking()
            .OrderByDescending(r => r.DateCreated)
            .FirstOrDefault();
          return resume;
        }
      }
    }
}
