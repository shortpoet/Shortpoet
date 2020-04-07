using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shortpoet.Data.Models.Resume
{
    public class Experience
    {
        public int Id { get; set; }
        // need to explicitly add foreign key id so that .Include() works when querying
        public int? ResumeId { get; set; }
        public virtual Resume Resume { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    }
}
