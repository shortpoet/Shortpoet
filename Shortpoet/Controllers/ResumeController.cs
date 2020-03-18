using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shortpoet.Data.Models;

namespace Shortpoet.Controllers
{
    // // [Authorize]
    // [ApiController]
    // [Route("api/[controller]/[action]")]
    public class ResumeController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public ResumeController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

    //   [HttpGet]
      public IActionResult Get()
      {
        string path = @".\VueClient\src\assets\carlos_resume.json";
        Resume resume = Resume.LoadJson(path);
        return new JsonResult(resume);
      }
    }
}
