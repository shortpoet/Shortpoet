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
using DbConnect.Data.Models.ResumeData;

namespace DbConnect
{
  public class Results
  {
    public static void  ShowDataTable(DataTable results)
    {
      try 
      {
        List<string> columns = new List<string>();
        foreach (DataColumn col in results.Columns)
        {
          columns.Add(col.ToString());
        }
        foreach (DataRow row in results.Rows)
        {
          foreach (var col in columns.Select((c, i) => new { c, i }))
          {
            Console.WriteLine(col.c);
            Console.WriteLine(row[col.i]);;
            Console.ReadLine();
          }
        }
        }
        catch (Exception e)
        {
          Console.WriteLine(e);
        }
    }
    public static void  ShowJson(Resume resume)
    {

      try 
      {
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(resume, Formatting.Indented, 
          new JsonSerializerSettings {
            // https://stackoverflow.com/questions/7397207/json-net-error-self-referencing-loop-detected-for-type 
            // this option prints empty arrays for the circular references
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            // this options adds $id and $ref
            // ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
            // PreserveReferencesHandling = PreserveReferencesHandling.Objects
        });
        Console.WriteLine(json);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }
    }
    }
}
