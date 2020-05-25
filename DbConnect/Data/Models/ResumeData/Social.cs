using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using YamlDotNet.Serialization;


namespace DbConnect.Data.Models.ResumeData
{
    public class SocialJson
    {
        [JsonProperty("socials")]
        public IList<Social> Socials { get; set; }
        public static SocialJson LoadSocials(string path, Boolean writeJson)
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

                SocialJson socials = JsonConvert.DeserializeObject<SocialJson>(json);

                return socials;
            }
        }
        public static SocialJson LoadJson(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                SocialJson resume = JsonConvert.DeserializeObject<SocialJson>(json);
                return resume;
            }
        }

    }

    public class Social
    {
        public int Id { get; set; }
        public string Provider { get; set; }
        public string Url { get; set; }
        public virtual ICollection<ResumeSocials> ResumeSocials { get; set; } = new List<ResumeSocials>();

    }
}
