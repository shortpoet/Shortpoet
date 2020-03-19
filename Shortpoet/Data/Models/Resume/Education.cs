using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shortpoet.Data.Models.Resume
{
    public class Education
    {
        public int EducationId { get; set; }
        public int? ResumeId { get; set; }
        public virtual Resume Resume { get; set; }
        public string Institution { get; set; }
        public string Degree { get; set; }
        public string Focus { get; set; }

    }
}
