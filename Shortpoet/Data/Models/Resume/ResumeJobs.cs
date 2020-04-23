using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using YamlDotNet.Serialization;

namespace Shortpoet.Data.Models.Resume
{
    public class ResumeJobsJson
    {
        [JsonProperty("resumeJobs")]
        public IList<ResumeJobs> ResumeJobs { get; set; }
        public static ResumeJobsJson LoadResumeJobs(string path, Boolean writeJson)
        {
            using (StreamReader r = new StreamReader(path))
            {
                var deserializer = new Deserializer();
		        var yamlObject = deserializer.Deserialize(r);
                
                var serializer = new Newtonsoft.Json.JsonSerializer();

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

                ResumeJobsJson resumeJobs = JsonConvert.DeserializeObject<ResumeJobsJson>(json);

                return resumeJobs;
            }
        }

    }
    public class ResumeJobs
    {
        public int ResumeId { get; set; }
        public virtual Resume Resume { get; set; }
        public int JobId { get; set; }
        public virtual Job Job { get; set; }

    }
}
