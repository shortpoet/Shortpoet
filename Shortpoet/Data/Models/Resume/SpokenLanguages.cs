using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using YamlDotNet.Serialization;
namespace Shortpoet.Data.Models.Resume
{
    public class LanguageJson
    {
        [JsonProperty("spokenLanguages")]
        public IList<SpokenLanguages> SpokenLanguages { get; set; }
        public static LanguageJson LoadLanguages(string path, Boolean writeJson)
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

                LanguageJson languages = JsonConvert.DeserializeObject<LanguageJson>(json);

                return languages;
            }
        }
        public static LanguageJson LoadJson(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                LanguageJson resume = JsonConvert.DeserializeObject<LanguageJson>(json);
                return resume;
            }
        }

    }

    public class SpokenLanguages
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Languages { get; set; }
        public bool TranslationInterpretationProfessional { get; set; }
        public virtual ICollection<ResumeSpokenLanguages> ResumeSpokenLanguages { get; set; } = new List<ResumeSpokenLanguages>();

    }
}
