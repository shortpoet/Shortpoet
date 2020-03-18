using Microsoft.AspNetCore.Identity;
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace Shortpoet.Data.Models
{
    public class Resume
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string AboutMe { get; set; }
        public ICollection<Experience> Experience { get; set; } = new List<Experience>();

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
