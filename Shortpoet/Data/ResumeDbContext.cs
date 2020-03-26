using Shortpoet.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shortpoet.Data.Models.Resume;

namespace Shortpoet.Data
{
  public class ResumeDbContext : DbContext
  {
    public ResumeDbContext (DbContextOptions<ResumeDbContext> options)
        : base(options)
    {
    }

    public DbSet<Resume> Resumes { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<SpokenLanguages> SpokenLanguages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Resume>().ToTable("Resumes", "Profiles")
        // .HasKey(r => r.ResumeId)
        ;
      modelBuilder.Entity<Education>().ToTable("Educations", "Profiles")
        // .HasKey(ed => ed.EducationId)
        ;
      modelBuilder.Entity<Experience>(builder => {
        builder.ToTable("Experiences", "Profiles");
        builder.HasKey(ex => ex.ExperienceId);
        // builder.HasKey(ex => new { ex.ResumeId, ex.ExperienceId });
        builder.HasOne(ex => ex.Resume)
          // must have value in WithMany call or duplicate foreign key is made on the navigation property ResumeId
          // adding nullable to foreign key props in data models avoided merge conflict on insert in dbInit bec it was trying to insert the jobs before the resume was created
          // but then it just inserts null values
          .WithMany(ex => ex.Experiences)
          .HasForeignKey(ex => ex.ResumeId)
        ;
        builder.HasMany(ex => ex.Jobs)
          .WithOne(ex => ex.Experience)
        ;
      });
      modelBuilder.Entity<Job>(builder => {
        builder.ToTable("Jobs", "Profiles");
        builder.HasOne(j => j.Experience)
          .WithMany(ex => ex.Jobs)
          .HasForeignKey(j => new { j.ResumeId })
            .OnDelete(DeleteBehavior.NoAction)
          .HasForeignKey(j => new { j.ExperienceId })
          // .HasForeignKey(j => new { j.ExperienceId, j.ResumeId })
            .OnDelete(DeleteBehavior.NoAction)
        ;
      });
      modelBuilder.Entity<Skill>().ToTable("Skills", "Profiles")
        // .HasKey(sk => sk.SkillId)
        ;
      modelBuilder.Entity<SpokenLanguages>().ToTable("SpokenLanguages", "Profiles")
        // .HasKey(sl => sl.SpokenLanguagesId)
        ;
    }
  }
}
