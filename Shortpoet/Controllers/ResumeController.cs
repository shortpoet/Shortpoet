using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shortpoet.Data.Models.Resume;
using Shortpoet.Data;

namespace Shortpoet.Controllers
{
    // // [Authorize]
    // [ApiController]
    // [Route("api/[controller]/[action]")]
    public class ResumeController : ControllerBase
    {
        private readonly ResumeDbContext _context;

        private readonly ILogger<ResumeController> _logger;

        public ResumeController(ILogger<ResumeController> logger, ResumeDbContext context)
        {
            _logger = logger;
            _context = context;

        }

    //   [HttpGet]
      public IActionResult Get()
      {
        string path = @"Data\Seed\carlos_resume.json";
        Resume resume = Resume.LoadJson(path);
        return new JsonResult(resume);
      }
      public async Task<IActionResult> Fetch(int id)
      {
        await _context.Resumes.LoadAsync();
        var resume = _context.Resumes
          .Include(r => r.ResumeEducations)
            .ThenInclude(r => r.Education)
          .Include(r => r.ResumeJobs)
            .ThenInclude(r => r.Job)
          .Include(r => r.ResumeSkills)
            .ThenInclude(r => r.Skill)
          .Include(r => r.ResumeSocials)
            .ThenInclude(r => r.Social)
          .Include(r => r.ResumeSpokenLanguages)
            .ThenInclude(r => r.SpokenLanguages)
          .AsNoTracking()
          .Where(r => r.Id == id)
          .FirstOrDefault();
        return new JsonResult(resume);
      }
      public async Task<IActionResult> FetchLatest()
      {
        await _context.Resumes.LoadAsync();
        var resume = _context.Resumes
          .Include(r => r.ResumeEducations)
            .ThenInclude(r => r.Education)
          .Include(r => r.ResumeJobs)
            .ThenInclude(r => r.Job)
          .Include(r => r.ResumeSkills)
            .ThenInclude(r => r.Skill)
          .Include(r => r.ResumeSocials)
            .ThenInclude(r => r.Social)
          .Include(r => r.ResumeSpokenLanguages)
            .ThenInclude(r => r.SpokenLanguages)
          .AsNoTracking()
          .OrderByDescending(r => r.DateCreated)
          .FirstOrDefault();
        return new JsonResult(resume);
      }
    }
}
