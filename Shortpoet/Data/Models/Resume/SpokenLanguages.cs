using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shortpoet.Data.Models.Resume
{
    public class SpokenLanguages
    {
        public int Id { get; set; }
        public int? ResumeId { get; set; }
        public virtual Resume Resume { get; set; }
        public string Type { get; set; }
        public string Languages { get; set; }
        public bool TranslationInterpretationProfessional { get; set; }

    }
}
