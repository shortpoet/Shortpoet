using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using YamlDotNet.Serialization;

namespace Shortpoet.Data.Models.ResumeData
{
    public class ResumeSocialsJson
    {
        [JsonProperty("resumeSocials")]
        public IList<ResumeSocials> ResumeSocials { get; set; }
        public static ResumeSocialsJson LoadResumeSocials(string path, Boolean writeJson)
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

                ResumeSocialsJson resumeSocials = JsonConvert.DeserializeObject<ResumeSocialsJson>(json);

                return resumeSocials;
            }
        }
        public static ResumeSocialsJson LoadJson(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                ResumeSocialsJson resumeSocials = JsonConvert.DeserializeObject<ResumeSocialsJson>(json);
                return resumeSocials;
            }
        }

    }
    public class ResumeSocials
    {
        public int ResumeId { get; set; }
        public virtual Resume Resume { get; set; }
        public int SocialId { get; set; }
        public virtual Social Social { get; set; }

    }
}
