using System;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

using Shortpoet.Data;
using Shortpoet.Data.Seed;
using Shortpoet.Data.Models.Resume;
using Shortpoet.Controllers;

namespace Shortpoet.Tests
{
    public class ResumeControllerShould
    {
        
        #region Seeding
        public ResumeControllerShould(ILogger<ResumeController> logger, DbContextOptions<ResumeDbContext> contextOptions)
        {
            _logger = logger;

            _contextOptions = contextOptions;

            Seed();
        }
        private readonly ILogger<ResumeController> _logger;
        protected DbContextOptions<ResumeDbContext> _contextOptions { get; }
        private void Seed ()
        {
            using (var context = new ResumeDbContext(_contextOptions))
            {
                context.Database.EnsureDeleted();
                DbInitializer.InitializeDb(context);
            }
        }

        #endregion

        #region GetResume
        [Fact]
        public async Task Get_resume()
        {
            using (var context = new ResumeDbContext(_contextOptions))
            {
                var controller = new ResumeController(_logger, context);

                var result = await controller.FetchLatest();
                var resume = new JsonResult(result);

                string path = @"Data\Seed\carlos_resume.json";
                Resume expected = Resume.LoadJson(path);

                Assert.NotNull(resume);
                // Assert.StrictEqual<Resume>(expected, resume);
                // Assert.Equal("ItemOne", items[0].Name);
                // Assert.Equal("ItemThree", items[1].Name);
                // Assert.Equal("ItemTwo", items[2].Name);
            }
        }    
        #endregion
    }
}
