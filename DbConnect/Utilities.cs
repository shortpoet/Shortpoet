using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using DbConnect.Data;
using DbConnect.Data.Models.ResumeData;

namespace DbConnect
{
  class Utilities
  {
    public static void LoadType<T>(ResumeDbContext context, string filePath, Boolean writeJson)
    {
        if (File.Exists(filePath)) 
        {
          using (StreamReader r = new StreamReader(filePath))
          {
            var deserializer = new Deserializer();
            var yamlObject = deserializer.Deserialize(r);
            
            var serializer = new Newtonsoft.Json.JsonSerializer();
            serializer.Formatting = Newtonsoft.Json.Formatting.Indented;

            string json;
            using (StringWriter w = new StringWriter()) 
            {
              serializer.Serialize(w, yamlObject);
              json = w.ToString();
            }
            
            if (writeJson) {
                string jsonPath = filePath.Replace("yml", "json");
                using (StreamWriter w2 = new StreamWriter(jsonPath)) 
                {
                  w2.Write(json);
                }
            }

            // string json = r.ReadToEnd();

            T output = JsonConvert.DeserializeObject<T>(json);

            context.Add(output);

          }

          Console.WriteLine("##############################");
          Console.WriteLine($"{filePath} written to database");
        }
        else
        {
          Console.WriteLine("##############################");
          Console.WriteLine($"No such file at: {filePath}");
        }

    }

    public static T SerializeYml<T>(string filePath)
    {
      if (File.Exists(filePath)) 
      {
        using (StreamReader r = new StreamReader(filePath))
        {
          var deserializer = new Deserializer();
          var yamlObject = deserializer.Deserialize(r);
            
          var serializer = new Newtonsoft.Json.JsonSerializer();
          serializer.Formatting = Newtonsoft.Json.Formatting.Indented;

          string json;
          using (StringWriter w = new StringWriter()) 
          {
              serializer.Serialize(w, yamlObject);
              json = w.ToString();
          }
          
          T output = JsonConvert.DeserializeObject<T>(json);

          Console.WriteLine("##############################");
          Console.WriteLine($"{filePath} serialized");
          return output;

        }
      }
      else
      {
        T output = default(T);
        Console.WriteLine("##############################");
        Console.WriteLine($"No such file at: {filePath}");
        return output;
      }
    }

    public static void YmlToJsonFile(string filePath)
    {
      if (File.Exists(filePath)) 
      {

        using (StreamReader r = new StreamReader(filePath))
        {

          var deserializer = new Deserializer();
          var yamlObject = deserializer.Deserialize(r);
            
          var serializer = new Newtonsoft.Json.JsonSerializer();
          serializer.Formatting = Newtonsoft.Json.Formatting.Indented;

          string json;
          using (StringWriter w = new StringWriter()) 
          {
            serializer.Serialize(w, yamlObject);
            json = w.ToString();
          }

          string jsonPath = filePath.Replace("yml", "json");
          using (StreamWriter w2 = new StreamWriter(jsonPath)) 
          {
            w2.Write(json);
            Console.WriteLine("##############################");
            Console.WriteLine($"JSON wrote at {jsonPath}");
          }
        }
      }
    }
    public static void WriteHardResume(string dateFolder, Resume resume)
    {

      ResumeFiles files =  new ResumeFiles(dateFolder);
      string ymlPath = files.HardResume;
      
      // write to json
      string json = JsonConvert.SerializeObject(
        resume,
        Formatting.Indented,
        new JsonSerializerSettings()
        { 
          ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        }     
      );

      string jsonPath = ymlPath.Replace("yml", "json");

      Resume decircularized = JsonConvert.DeserializeObject<Resume>(json);
      
      using (StreamWriter w = new StreamWriter(jsonPath)) 
      {
        w.Write(json);
        Console.WriteLine("##############################");
        Console.WriteLine($"JSON wrote at {jsonPath}");
      }

      //write to yml
      var serializer = new YamlDotNet.Serialization.Serializer();

      string yaml;
      
      using (StringWriter w = new StringWriter()) 
      {
        serializer.Serialize(w, decircularized);
        yaml = w.ToString();
      }

      using (StreamWriter w2 = new StreamWriter(ymlPath)) 
      {
        w2.Write(yaml);
        Console.WriteLine("##############################");
        Console.WriteLine($"YML wrote at {ymlPath}");
      }

      // write to javascript
      string javascript = "export default " + json;
      string jsPath = files.JavaScriptPath;
      Console.WriteLine(jsPath);
      using (StreamWriter w3 = new StreamWriter(jsPath)) 
      {
        w3.Write(javascript);
        Console.WriteLine("##############################");
        Console.WriteLine($"JS wrote at {jsPath}");
      }
    }

  }
}