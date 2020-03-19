using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shortpoet.Data.Models.Resume
{
    public class Job
    {
        public int JobId { get; set; }
        public int? ResumeId { get; set; }
        public virtual Experience Experience { get; set; }
        public int? ExperienceId { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
