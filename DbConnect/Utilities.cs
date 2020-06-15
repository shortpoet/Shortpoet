using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using DbConnect.Data;
using DbConnect.Data.Models.ResumeData;
using Newtonsoft.Json.Serialization;

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
      string jsonDCircle = JsonConvert.SerializeObject(
        resume,
        new JsonSerializerSettings()
        { 
          ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
          Formatting = Formatting.Indented,
          ContractResolver = new DefaultContractResolver
          {
            NamingStrategy = new CamelCaseNamingStrategy()
          }
        }     
      );

      string jsonPath = ymlPath.Replace("yml", "json");

      Resume resumeDCircle = JsonConvert.DeserializeObject<Resume>(jsonDCircle);

      ResumeDTO parsed = parseResume(resumeDCircle);

      string json = JsonConvert.SerializeObject(
        parsed,
        new JsonSerializerSettings()
        { 
          ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
          Formatting = Formatting.Indented,
          ContractResolver = new DefaultContractResolver
          {
            NamingStrategy = new CamelCaseNamingStrategy()
          }
        }     
      );
      
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
        serializer.Serialize(w, parsed);
        yaml = w.ToString();
      }

      using (StreamWriter w2 = new StreamWriter(ymlPath)) 
      {
        w2.Write(yaml);
        Console.WriteLine("##############################");
        Console.WriteLine($"YML wrote at {ymlPath}");
      }

      // write to javascript
      string javascript = "exports.resume = " + json;
      string jsPath = files.JavaScriptPath;
      Console.WriteLine(jsPath);
      using (StreamWriter w3 = new StreamWriter(jsPath)) 
      {
        w3.Write(javascript);
        Console.WriteLine("##############################");
        Console.WriteLine($"JS wrote at {jsPath}");
      }
    }
  private static List<Experience> parseExperiences(IEnumerable<Job> jobs)
  {
    List<Experience> experiences = new List<Experience>();
    foreach (ExperienceType type in (ExperienceType[]) Enum.GetValues(typeof(ExperienceType)))
    {
      experiences.Add(new Experience(){
        Type = type.ToString(),
        Jobs = jobs.Select(j => j).Where(j => j.ExperienceType == type.ToString()).ToList()
      });
    }
    return experiences;
  }
    public static ResumeDTO parseResume(Resume input)
    {
      ResumeDTO resume = new ResumeDTO()
      {
        AboutMe = input.AboutMe,
        Address = input.Address,
        Brief = input.Brief,
        Email = input.Email,
        Flags = input.Flags,
        Interests = input.Interests,
        Name = input.Name,
        Surname = input.Surname,
        Title = input.Title,
        Visas = input.Visas,
        Educations = input.ResumeEducations.Select(e => e.Education).ToList(),
        Jobs = input.ResumeJobs.Select(j => j.Job).ToList(),
        Skills = input.ResumeSkills.Select(sk => sk.Skill).ToList(),
        Socials = input.ResumeSocials.Select(so => so.Social).ToList(),
        SpokenLanguages = input.ResumeSpokenLanguages.Select(sp => sp.SpokenLanguages).ToList(),
        Experiences = parseExperiences(input.ResumeJobs.Select(j => j.Job)),
        DateCreated = input.DateCreated,
        Comments = input.Comments
      };
      return resume;
    }
  }
}