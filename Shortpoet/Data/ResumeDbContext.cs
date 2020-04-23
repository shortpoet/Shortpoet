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

    public DbSet<Education> Educations { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Resume> Resumes { get; set; }
    public DbSet<ResumeEducations> ResumeEducations { get; set; }
    public DbSet<ResumeJobs> ResumeJobs { get; set; }
    public DbSet<ResumeSpokenLanguages> ResumeSpokenLanguages { get; set; }
    public DbSet<ResumeSkills> ResumeSkills { get; set; }
    public DbSet<ResumeSocials> ResumeSocials { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Social> Socials { get; set; }
    public DbSet<SpokenLanguages> SpokenLanguages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Education>().ToTable("Educations", "Profiles")
        .HasKey(ed => ed.Id)
        ;
      modelBuilder.Entity<Job>(builder => {
        builder.ToTable("Jobs", "Profiles");
        builder.HasKey(j => j.Id);
      });
      modelBuilder.Entity<Resume>().ToTable("Resumes", "Profiles")
        .HasKey(r => r.Id)
        ;
      modelBuilder.Entity<ResumeEducations>(builder => {
        builder.ToTable("ResumeEducations", "Profiles");
        builder.HasKey(red => new {red.ResumeId, red.EducationId});
      });
      modelBuilder.Entity<ResumeJobs>(builder => {
        builder.ToTable("ResumeJobs", "Profiles");
        builder.HasKey(rej => new {rej.ResumeId, rej.JobId});
      });
      modelBuilder.Entity<ResumeSpokenLanguages>(builder => {
        builder.ToTable("ResumeSpokenLanguages", "Profiles");
        builder.HasKey(rel => new {rel.ResumeId, rel.SpokenLanguagesId});
      });
      modelBuilder.Entity<ResumeSkills>(builder => {
        builder.ToTable("ResumeSkills", "Profiles");
        builder.HasKey(resk => new {resk.ResumeId, resk.SkillId});
      });
      modelBuilder.Entity<ResumeSocials>(builder => {
        builder.ToTable("ResumeSocials", "Profiles");
        builder.HasKey(reso => new {reso.ResumeId, reso.SocialId});
      });
      modelBuilder.Entity<Skill>().ToTable("Skills", "Profiles")
        .HasKey(sk => sk.Id)
        ;
      modelBuilder.Entity<Social>().ToTable("Socials", "Profiles")
        .HasKey(so => so.Id)
        ;
      modelBuilder.Entity<SpokenLanguages>().ToTable("SpokenLanguages", "Profiles")
        .HasKey(sl => sl.Id)
        ;
    }
  }
}
