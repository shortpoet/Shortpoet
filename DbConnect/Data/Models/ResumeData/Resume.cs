
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace DbConnect.Data.Models.ResumeData
{
    public class Resume
    {
        public int Id { get; set; }
        // https://stackoverflow.com/questions/691035/setting-the-default-value-of-a-datetime-property-to-datetime-now-inside-the-syst

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Visas { get; set; }
        public string Flags { get; set; }
        public string Brief { get; set; }
        public string AboutMe { get; set; }
        public string Interests { get; set; }
        public virtual ICollection<ResumeEducations> ResumeEducations { get; set; } = new List<ResumeEducations>();
        public virtual ICollection<ResumeJobs> ResumeJobs { get; set; } = new List<ResumeJobs>();
        public virtual ICollection<ResumeSpokenLanguages> ResumeSpokenLanguages { get; set; } = new List<ResumeSpokenLanguages>();
        public virtual ICollection<ResumeSkills> ResumeSkills { get; set; } = new List<ResumeSkills>();
        public virtual ICollection<ResumeSocials> ResumeSocials { get; set; } = new List<ResumeSocials>();

        public static Resume LoadJson(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                Resume resume = JsonConvert.DeserializeObject<Resume>(json);
                Console.Write(resume);
                return resume;
            }
        }

        // this method throws
        // 
        // YamlDotNet.Core.YamlException: (Line: 1, Col: 1, Idx: 0) - (Line: 1, Col: 1, Idx: 0): Exception during deserialization
        // ---> System.Runtime.Serialization.SerializationException: Property 'title' not found on type 'Shortpoet.Data.Models.Resume.Resume'.
        // 
        // probably due to casing 'title' vs 'Title'
        public static Resume YmlToResume(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {                
                var deserializer = new Deserializer();

		        Resume resume = deserializer.Deserialize<Resume>(r);
                
                return resume;

            }
        }
        public static object LoadYml(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                var deserializer = new Deserializer();
		        var yamlObject = deserializer.Deserialize(r);
                return yamlObject;
            }
        }

        
        public static Resume LoadType(ResumeDbContext context, string path, Boolean writeJson)
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

                Resume resume = JsonConvert.DeserializeObject<Resume>(json);

                context.Add(resume);

                return resume;
            }
        }

        

    }
}
