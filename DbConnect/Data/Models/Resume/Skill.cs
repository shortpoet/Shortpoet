using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using YamlDotNet.Serialization;


namespace DbConnect.Data.Models.Resume
{
    public class SkillJson
    {
        [JsonProperty("skills")]
        public IList<Skill> Skills { get; set; }
        public static SkillJson LoadSkills(string path, Boolean writeJson)
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

                return skills;
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


    }

    public class Skill
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Details { get; set; }
        public virtual ICollection<ResumeSkills> ResumeSkills { get; set; } = new List<ResumeSkills>();

    }
}
