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

        private readonly ILogger<WeatherForecastController> _logger;

        public ResumeController(ILogger<WeatherForecastController> logger, ResumeDbContext context)
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
          .Include(r => r.Educations)
          .Include(r => r.Experiences)
            .ThenInclude(e => e.Jobs)
          .Include(r => r.Skills)
          .Include(r => r.SpokenLanguages)
          .AsNoTracking()
          .Where(r => r.Id == id)
          .FirstOrDefault();
        return new JsonResult(resume);
      }
    }
}
