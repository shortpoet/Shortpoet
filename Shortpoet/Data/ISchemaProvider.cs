using Shortpoet.Data;
using Microsoft.AspNetCore.Hosting;

public interface ISchemaProvider {
    string GetSchemaName();
}

public class SchemaProvider : ISchemaProvider {
    private readonly ResumeDbContext _context;
    private readonly IWebHostEnvironment _env;    

    public SchemaProvider(ResumeDbContext context, IWebHostEnvironment env) {
        _context = context;
        _env = env;
    }
    public string GetSchemaName() {
      if( _env.EnvironmentName == "Production")
      {
        return "Profile";
      } else {
        return "TestProfile";
      }
    }
}