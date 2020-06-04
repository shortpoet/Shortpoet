using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using DbConnect.Data;
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

  }
}