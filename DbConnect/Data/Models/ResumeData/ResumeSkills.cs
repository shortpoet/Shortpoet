﻿using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using YamlDotNet.Serialization;

namespace DbConnect.Data.Models.ResumeData
{
    public class ResumeSkillsJson
    {
        [JsonProperty("resumeSkills")]
        public IList<ResumeSkills> ResumeSkills { get; set; }
        public static ResumeSkillsJson LoadType(string path, Boolean writeJson)
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
                ResumeSkillsJson resumeSkills = JsonConvert.DeserializeObject<ResumeSkillsJson>(json);
                return resumeSkills;
            }
        }

    }
    public class ResumeSkills
    {
        public int ResumeId { get; set; }
        public virtual Resume Resume { get; set; }
        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
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
