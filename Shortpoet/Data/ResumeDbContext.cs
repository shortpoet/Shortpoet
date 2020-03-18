using Shortpoet.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shortpoet.Data.Models;

namespace Shortpoet.Data
{
  public class ResumeDbContext : DbContext
  {
    public ResumeDbContext (DbContextOptions<ResumeDbContext> options)
        : base(options)
    {
    }

    public DbSet<Resume> Resume { get; set; }
    public DbSet<Experience> Experience { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Resume>().ToTable("Resumes", "Profile");
      modelBuilder.Entity<Experience>().ToTable("Experiences", "Profile");
        // .HasKey(l => l.pkid);
    }
  }
}
