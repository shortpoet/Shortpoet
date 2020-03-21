using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Shortpoet.Pages
{
    public class RazorIndexModel : PageModel
    {
        private readonly ILogger<RazorIndexModel> _logger;
        public string Message { get; set; }
        public RazorIndexModel(ILogger<RazorIndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
          Message = HttpContext.Request.PathBase;
        }
    }
}
