using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using YamlDotNet.Serialization;

namespace DbConnect.Data.Models.ResumeData

{
    public class Education
    {
        public int Id { get; set; }
        public string Institution { get; set; }
        public string Degree { get; set; }
        public string Focus { get; set; }
        public virtual ICollection<ResumeEducations> ResumeEducations { get; set; } = new List<ResumeEducations>();
        public DateTime DateCreated { get; set; } = DateTime.Now;

        // public DateTime DateCreated
        // {
        //     get => dateCreated ?? DateTime.Now;
        //     set => this.dateCreated = value;
        // }
        // private DateTime? dateCreated = null;
        public string Comments { get; set; }

    }

    public class EducationJson
    {
        [JsonProperty("educations")]
        public IList<Education> Educations { get; set; }

        public static IList<Education> LoadType(ResumeDbContext context, string path, Boolean writeJson)
        {
            // if (File.Exists(filePath)) 
            // {
            //   Console.WriteLine("##############################");
            //   Console.WriteLine($"{filePath} written to database");
            // }
            // else
            // {
            //   Console.WriteLine("##############################");
            //   Console.WriteLine($"No such file at: {filePath}");
            // }
            using (StreamReader r = new StreamReader(path))
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
                    string jsonPath = path.Replace("yml", "json");
                    using (StreamWriter w2 = new StreamWriter(jsonPath)) 
                    {
                        w2.Write(json);
                    }
                }

                // string json = r.ReadToEnd();

                EducationJson educations = JsonConvert.DeserializeObject<EducationJson>(json);

                context.Add(educations.Educations);

                return educations.Educations;
            }

        }
        public static EducationJson LoadJson(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                EducationJson resume = JsonConvert.DeserializeObject<EducationJson>(json);
                return resume;
            }
        }

    }
}
