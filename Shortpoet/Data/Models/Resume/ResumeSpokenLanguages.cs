using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using YamlDotNet.Serialization;

namespace Shortpoet.Data.Models.Resume
{
    public class ResumeSpokenLanguagesJson
    {
        [JsonProperty("resumeSpokenLanguages")]
        public IList<ResumeSpokenLanguages> ResumeSpokenLanguages { get; set; }
        public static ResumeSpokenLanguagesJson LoadResumeSpokenLanguages(string path, Boolean writeJson)
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

                ResumeSpokenLanguagesJson resumeSpokenLanguages = JsonConvert.DeserializeObject<ResumeSpokenLanguagesJson>(json);

                return resumeSpokenLanguages;
            }
        }
        public static ResumeSpokenLanguagesJson LoadJson(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                ResumeSpokenLanguagesJson resumeSpokenLanguages = JsonConvert.DeserializeObject<ResumeSpokenLanguagesJson>(json);
                return resumeSpokenLanguages;
            }
        }

    }
    public class ResumeSpokenLanguages
    {
        public int ResumeId { get; set; }
        public virtual Resume Resume { get; set; }
        public int SpokenLanguagesId { get; set; }
        public virtual SpokenLanguages SpokenLanguages { get; set; }

    }
}
