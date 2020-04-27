using DbConnect.Data.Models.Resume;
using Microsoft.EntityFrameworkCore;

namespace DbConnect.Data
{
  public class ResumeDbContext : DbContext
  {

    // https://stackoverflow.com/questions/41420957/how-can-i-get-ihostingenvironment-from-dbcontext-in-asp-net-core
    // https://stackoverflow.com/questions/39499470/dynamically-changing-schema-in-entity-framework-core/50529432#50529432
    // ended up setting this using db login and roles default schema which are triggered by env vars
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
      
      modelBuilder.Entity<Education>(builder => {
        builder.ToTable("Educations");
        builder.HasKey(ed => ed.Id);
      });
      modelBuilder.Entity<Job>(builder => {
        builder.ToTable("Jobs");
        builder.HasKey(j => j.Id);
      });
      modelBuilder.Entity<Resume>(builder => {
        builder.ToTable("Resumes")
          .HasKey(r => r.Id)
        ;
      });
      modelBuilder.Entity<Skill>()
        .ToTable("Skills")
        .HasKey(sk => sk.Id)
        ;
      modelBuilder.Entity<Social>()
        .ToTable("Socials")
        .HasKey(so => so.Id)
        ;
      modelBuilder.Entity<SpokenLanguages>()
        .ToTable("SpokenLanguages")
        .HasKey(sl => sl.Id)
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
    }
  }
}
