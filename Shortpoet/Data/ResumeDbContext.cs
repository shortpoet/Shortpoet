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
using Microsoft.AspNetCore.Hosting;

namespace Shortpoet.Data
{
  public class ResumeDbContext : DbContext
  {

    // https://stackoverflow.com/questions/41420957/how-can-i-get-ihostingenvironment-from-dbcontext-in-asp-net-core
    // https://stackoverflow.com/questions/39499470/dynamically-changing-schema-in-entity-framework-core/50529432#50529432
    private readonly IWebHostEnvironment _env;
    // public ResumeDbContext (IWebHostEnvironment env, DbContextOptions<ResumeDbContext> options)
    //     : base(options)
    // {
    //   _env = env;
    // }

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
    private string dynamicSchema;
    public void GetSchemaName() {
      if(_env.EnvironmentName == "Production")
      {
        Console.WriteLine("######################");
        Console.WriteLine("## Get Schema Name");
        Console.WriteLine(_env.EnvironmentName);
        dynamicSchema =  "Profiles";
      } else {
        Console.WriteLine("######################");
        Console.WriteLine("## Get Schema Name");
        Console.WriteLine(_env.EnvironmentName);
        dynamicSchema = "TestProfiles";
      }
    }
    // private string schemaName = dynamicSchema;
    // private string schemaName = "Profiles";
    // private string schemaName = "TestProfiles";

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      
      modelBuilder.Entity<Education>().ToTable("Educations")
        .HasKey(ed => ed.Id)
        ;
      modelBuilder.Entity<Job>(builder => {
        builder.ToTable("Jobs");
        builder.HasKey(j => j.Id);
      });
      modelBuilder.Entity<Resume>().ToTable("Resumes")
        .HasKey(r => r.Id)
        ;
      modelBuilder.Entity<ResumeEducations>(builder => {
        builder.ToTable("ResumeEducations");
        builder.HasKey(red => new {red.ResumeId, red.EducationId});
      });
      modelBuilder.Entity<ResumeJobs>(builder => {
        builder.ToTable("ResumeJobs");
        builder.HasKey(rej => new {rej.ResumeId, rej.JobId});
      });
      modelBuilder.Entity<ResumeSpokenLanguages>(builder => {
        builder.ToTable("ResumeSpokenLanguages");
        builder.HasKey(rel => new {rel.ResumeId, rel.SpokenLanguagesId});
      });
      modelBuilder.Entity<ResumeSkills>(builder => {
        builder.ToTable("ResumeSkills");
        builder.HasKey(resk => new {resk.ResumeId, resk.SkillId});
      });
      modelBuilder.Entity<ResumeSocials>(builder => {
        builder.ToTable("ResumeSocials");
        builder.HasKey(reso => new {reso.ResumeId, reso.SocialId});
      });
      modelBuilder.Entity<Skill>().ToTable("Skills")
        .HasKey(sk => sk.Id)
        ;
      modelBuilder.Entity<Social>().ToTable("Socials")
        .HasKey(so => so.Id)
        ;
      modelBuilder.Entity<SpokenLanguages>().ToTable("SpokenLanguages")
        .HasKey(sl => sl.Id)
        ;
    }
  }
}
