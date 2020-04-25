using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using YamlDotNet.Serialization;

namespace Shortpoet.Data.Models.Resume
{
    public class EducationJson
    {
        [JsonProperty("educations")]
        public IList<Education> Educations { get; set; }
        public static EducationJson LoadEducations(string path, Boolean writeJson)
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

                EducationJson educations = JsonConvert.DeserializeObject<EducationJson>(json);

                return educations;
            }
        }

    }
    public class Education
    {
        public int Id { get; set; }
        public string Institution { get; set; }
        public string Degree { get; set; }
        public string Focus { get; set; }
        public virtual ICollection<ResumeEducations> ResumeEducations { get; set; } = new List<ResumeEducations>();

    }
}
