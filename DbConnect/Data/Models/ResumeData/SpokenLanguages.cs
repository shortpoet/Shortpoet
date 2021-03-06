using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using YamlDotNet.Serialization;
namespace DbConnect.Data.Models.ResumeData
{
    public class SpokenLanguages
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Languages { get; set; }
        public bool TranslationInterpretationProfessional { get; set; }
        public virtual ICollection<ResumeSpokenLanguages> ResumeSpokenLanguages { get; set; } = new List<ResumeSpokenLanguages>();
        public DateTime DateCreated { get; set; } = DateTime.Now;

        // public DateTime DateCreated
        // {
        //     get => dateCreated ?? DateTime.Now;
        //     set => this.dateCreated = value;
        // }
        // private DateTime? dateCreated = null;
        public string Comments { get; set; }

    }

    public class SpokenLanguagesJson
    {
        [JsonProperty("spokenLanguages")]
        public IList<SpokenLanguages> SpokenLanguages { get; set; }
        public static IList<SpokenLanguages> LoadType(ResumeDbContext context, string path, Boolean writeJson)
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

                SpokenLanguagesJson spokenLanguages = JsonConvert.DeserializeObject<SpokenLanguagesJson>(json);
                context.Add(spokenLanguages.SpokenLanguages);
                return spokenLanguages.SpokenLanguages;
            }
        }
        public static SpokenLanguagesJson LoadJson(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                SpokenLanguagesJson resume = JsonConvert.DeserializeObject<SpokenLanguagesJson>(json);
                return resume;
            }
        }

    }
}
