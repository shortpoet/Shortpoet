using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using YamlDotNet.Serialization;

namespace DbConnect.Data.Models.ResumeData
{
    public class JobJson
    {
        [JsonProperty("jobs")]
        public IList<Job> Jobs { get; set; }
        public static JobJson LoadJobs(string path, Boolean writeJson)
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

                JobJson jobs = JsonConvert.DeserializeObject<JobJson>(json);

                return jobs;
            }
        }
        public static JobJson LoadJson(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                JobJson resume = JsonConvert.DeserializeObject<JobJson>(json);
                return resume;
            }
        }

    }

    public class Job
    {
        public int Id { get; set; }
        public string ExperienceType { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }
}
