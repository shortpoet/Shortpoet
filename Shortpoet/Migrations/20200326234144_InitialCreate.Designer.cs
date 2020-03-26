﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shortpoet.Data;

namespace Shortpoet.Migrations
{
    [DbContext(typeof(ResumeDbContext))]
    [Migration("20200326234144_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Shortpoet.Data.Models.Resume.Education", b =>
                {
                    b.Property<int>("EducationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Degree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Focus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Institution")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResumeId")
                        .HasColumnType("int");

                    b.HasKey("EducationId");

                    b.HasIndex("ResumeId");

                    b.ToTable("Educations","Profiles");
                });

            modelBuilder.Entity("Shortpoet.Data.Models.Resume.Experience", b =>
                {
                    b.Property<int>("ExperienceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ResumeId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExperienceId");

                    b.HasIndex("ResumeId");

                    b.ToTable("Experiences","Profiles");
                });

            modelBuilder.Entity("Shortpoet.Data.Models.Resume.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExperienceId")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResumeId")
                        .HasColumnType("int");

                    b.Property<string>("StartDate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobId");

                    b.HasIndex("ExperienceId");

                    b.ToTable("Jobs","Profiles");
                });

            modelBuilder.Entity("Shortpoet.Data.Models.Resume.Resume", b =>
                {
                    b.Property<int>("ResumeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutMe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Interests")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResumeId");

                    b.ToTable("Resumes","Profiles");
                });

            modelBuilder.Entity("Shortpoet.Data.Models.Resume.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResumeId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SkillId");

                    b.HasIndex("ResumeId");

                    b.ToTable("Skills","Profiles");
                });

            modelBuilder.Entity("Shortpoet.Data.Models.Resume.SpokenLanguages", b =>
                {
                    b.Property<int>("SpokenLanguagesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Languages")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResumeId")
                        .HasColumnType("int");

                    b.Property<bool>("TranslationInterpretationProfessional")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpokenLanguagesId");

                    b.HasIndex("ResumeId");

                    b.ToTable("SpokenLanguages","Profiles");
                });

            modelBuilder.Entity("Shortpoet.Data.Models.Resume.Education", b =>
                {
                    b.HasOne("Shortpoet.Data.Models.Resume.Resume", "Resume")
                        .WithMany("Educations")
                        .HasForeignKey("ResumeId");
                });

            modelBuilder.Entity("Shortpoet.Data.Models.Resume.Experience", b =>
                {
                    b.HasOne("Shortpoet.Data.Models.Resume.Resume", "Resume")
                        .WithMany("Experiences")
                        .HasForeignKey("ResumeId");
                });

            modelBuilder.Entity("Shortpoet.Data.Models.Resume.Job", b =>
                {
                    b.HasOne("Shortpoet.Data.Models.Resume.Experience", "Experience")
                        .WithMany("Jobs")
                        .HasForeignKey("ExperienceId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Shortpoet.Data.Models.Resume.Skill", b =>
                {
                    b.HasOne("Shortpoet.Data.Models.Resume.Resume", "Resume")
                        .WithMany("Skills")
                        .HasForeignKey("ResumeId");
                });

            modelBuilder.Entity("Shortpoet.Data.Models.Resume.SpokenLanguages", b =>
                {
                    b.HasOne("Shortpoet.Data.Models.Resume.Resume", "Resume")
                        .WithMany("SpokenLanguages")
                        .HasForeignKey("ResumeId");
                });
#pragma warning restore 612, 618
        }
    }
}
