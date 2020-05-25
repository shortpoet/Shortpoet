
using Microsoft.EntityFrameworkCore;

namespace Shortpoet.Data.Models.BlogData
{
  public class BlogDbContext : DbContext
  {

    // https://stackoverflow.com/questions/41420957/how-can-i-get-ihostingenvironment-from-dbcontext-in-asp-net-core
    // https://stackoverflow.com/questions/39499470/dynamically-changing-schema-in-entity-framework-core/50529432#50529432
    // ended up setting this using db login and roles default schema which are triggered by env vars
    public BlogDbContext (DbContextOptions<BlogDbContext> options)
        : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      
      modelBuilder.Entity<Post>(builder => {
        builder.ToTable("Posts");
        builder.HasKey(p => p.Id);
      });
    }
  }
}
