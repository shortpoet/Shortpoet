
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace DbConnect.Data.Models.ResumeData
{
    public enum ExperienceType
    {
        software,
        language,
        hospitality
    }
    public class Experience
    {
        public string Type { get; set; }
        public ICollection<Job> Jobs = new List<Job>();
    }
    public class ResumeDTO
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
        public ICollection<Education> Educations { get; set; } = new List<Education>();
        public ICollection<Job> Jobs { get; set; } = new List<Job>();
        public ICollection<SpokenLanguages> SpokenLanguages { get; set; } = new List<SpokenLanguages>();
        public ICollection<Skill> Skills { get; set; } = new List<Skill>();
        public ICollection<Social> Socials { get; set; } = new List<Social>();
        public ICollection<Experience> Experiences { get; set; } = new List<Experience>();
        public DateTime DateCreated { get; set; }
        public string Comments { get; set; }        

    }
}
