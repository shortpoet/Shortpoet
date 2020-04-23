using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using YamlDotNet.Serialization;

namespace Shortpoet.Data.Models.Resume
{
    public class ResumeEducationsJson
    {
        [JsonProperty("resumeEducations")]
        public IList<ResumeEducations> ResumeEducations { get; set; }
        public static ResumeEducationsJson LoadResumeEducations(string path, Boolean writeJson)
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

                ResumeEducationsJson resumeEducations = JsonConvert.DeserializeObject<ResumeEducationsJson>(json);

                return resumeEducations;
            }
        }

    }

    public class ResumeEducations
    {
        public int ResumeId { get; set; }
        public virtual Resume Resume { get; set; }
        public int EducationId { get; set; }
        public virtual Education Education { get; set; }

    }
}
