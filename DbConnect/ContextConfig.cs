using Microsoft.EntityFrameworkCore;
using DbConnect.Data;

namespace DbConnect
{
  public class ContextConfig
  {
    public static DbContextOptions<ResumeDbContext> GetConfig(string connStr)
    {
      var optionsBuilder = new DbContextOptionsBuilder<ResumeDbContext>();
      optionsBuilder
        .UseSqlServer(connStr)
        .EnableSensitiveDataLogging()
        ;
      return optionsBuilder.Options;
    }

  }
}