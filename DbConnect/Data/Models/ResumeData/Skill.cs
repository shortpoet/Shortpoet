using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using YamlDotNet.Serialization;


namespace DbConnect.Data.Models.ResumeData
{
    public class Skill
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Details { get; set; }
        public virtual ICollection<ResumeSkills> ResumeSkills { get; set; } = new List<ResumeSkills>();

    }

    public class SkillJson
    {
        [JsonProperty("skills")]
        public IList<Skill> Skills { get; set; }
        public static IList<Skill> LoadType(ResumeDbContext context, string path, Boolean writeJson)
        {
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

                SkillJson skills = JsonConvert.DeserializeObject<SkillJson>(json);

                context.Add(skills.Skills);

                return skills.Skills;
            }
        }
        public static SkillJson LoadJson(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                SkillJson resume = JsonConvert.DeserializeObject<SkillJson>(json);
                return resume;
            }
        }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        // public DateTime DateCreated
        // {
        //     get => dateCreated ?? DateTime.Now;
        //     set => this.dateCreated = value;
        // }
        // private DateTime? dateCreated = null;
        public string Comments { get; set; }


    }
}
