using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using YamlDotNet.Serialization;

namespace Shortpoet.Data.Models.Resume
{
    public class ResumeSkillsJson
    {
        [JsonProperty("resumeSkills")]
        public IList<ResumeSkills> ResumeSkills { get; set; }
        public static ResumeSkillsJson LoadResumeSkills(string path, Boolean writeJson)
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

                ResumeSkillsJson resumeSkills = JsonConvert.DeserializeObject<ResumeSkillsJson>(json);

                return resumeSkills;
            }
        }
        public static ResumeSkillsJson LoadJson(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                ResumeSkillsJson resume = JsonConvert.DeserializeObject<ResumeSkillsJson>(json);
                return resume;
            }
        }

    }
    public class ResumeSkills
    {
        public int ResumeId { get; set; }
        public virtual Resume Resume { get; set; }
        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }

    }
}
