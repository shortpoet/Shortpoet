using Microsoft.AspNetCore.Identity;
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace Shortpoet.Data.Models.Resume
{
    public class Resume
    {
        public int Id { get; set; }
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
        public virtual ICollection<Education> Educations { get; set; } = new List<Education>();
        public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();
        public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
        public virtual ICollection<SpokenLanguages> SpokenLanguages { get; set; } = new List<SpokenLanguages>();

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

    }
}
