using Microsoft.EntityFrameworkCore.Migrations;

namespace Shortpoet.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Profiles");

            migrationBuilder.CreateTable(
                name: "Educations",
                schema: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Institution = table.Column<string>(nullable: true),
                    Degree = table.Column<string>(nullable: true),
                    Focus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                schema: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExperienceType = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StartDate = table.Column<string>(nullable: true),
                    EndDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resumes",
                schema: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Visas = table.Column<string>(nullable: true),
                    Flags = table.Column<string>(nullable: true),
                    Brief = table.Column<string>(nullable: true),
                    AboutMe = table.Column<string>(nullable: true),
                    Interests = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                schema: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Socials",
                schema: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Provider = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpokenLanguages",
                schema: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Languages = table.Column<string>(nullable: true),
                    TranslationInterpretationProfessional = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpokenLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResumeEducations",
                schema: "Profiles",
                columns: table => new
                {
                    ResumeId = table.Column<int>(nullable: false),
                    EducationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeEducations", x => new { x.ResumeId, x.EducationId });
                    table.ForeignKey(
                        name: "FK_ResumeEducations_Educations_EducationId",
                        column: x => x.EducationId,
                        principalSchema: "Profiles",
                        principalTable: "Educations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeEducations_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalSchema: "Profiles",
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeJobs",
                schema: "Profiles",
                columns: table => new
                {
                    ResumeId = table.Column<int>(nullable: false),
                    JobId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeJobs", x => new { x.ResumeId, x.JobId });
                    table.ForeignKey(
                        name: "FK_ResumeJobs_Jobs_JobId",
                        column: x => x.JobId,
                        principalSchema: "Profiles",
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeJobs_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalSchema: "Profiles",
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeSkills",
                schema: "Profiles",
                columns: table => new
                {
                    ResumeId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeSkills", x => new { x.ResumeId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_ResumeSkills_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalSchema: "Profiles",
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "Profiles",
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeSocials",
                schema: "Profiles",
                columns: table => new
                {
                    ResumeId = table.Column<int>(nullable: false),
                    SocialId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeSocials", x => new { x.ResumeId, x.SocialId });
                    table.ForeignKey(
                        name: "FK_ResumeSocials_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalSchema: "Profiles",
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeSocials_Socials_SocialId",
                        column: x => x.SocialId,
                        principalSchema: "Profiles",
                        principalTable: "Socials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeSpokenLanguages",
                schema: "Profiles",
                columns: table => new
                {
                    ResumeId = table.Column<int>(nullable: false),
                    SpokenLanguagesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeSpokenLanguages", x => new { x.ResumeId, x.SpokenLanguagesId });
                    table.ForeignKey(
                        name: "FK_ResumeSpokenLanguages_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalSchema: "Profiles",
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeSpokenLanguages_SpokenLanguages_SpokenLanguagesId",
                        column: x => x.SpokenLanguagesId,
                        principalSchema: "Profiles",
                        principalTable: "SpokenLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResumeEducations_EducationId",
                schema: "Profiles",
                table: "ResumeEducations",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeJobs_JobId",
                schema: "Profiles",
                table: "ResumeJobs",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeSkills_SkillId",
                schema: "Profiles",
                table: "ResumeSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeSocials_SocialId",
                schema: "Profiles",
                table: "ResumeSocials",
                column: "SocialId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeSpokenLanguages_SpokenLanguagesId",
                schema: "Profiles",
                table: "ResumeSpokenLanguages",
                column: "SpokenLanguagesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResumeEducations",
                schema: "Profiles");

            migrationBuilder.DropTable(
                name: "ResumeJobs",
                schema: "Profiles");

            migrationBuilder.DropTable(
                name: "ResumeSkills",
                schema: "Profiles");

            migrationBuilder.DropTable(
                name: "ResumeSocials",
                schema: "Profiles");

            migrationBuilder.DropTable(
                name: "ResumeSpokenLanguages",
                schema: "Profiles");

            migrationBuilder.DropTable(
                name: "Educations",
                schema: "Profiles");

            migrationBuilder.DropTable(
                name: "Jobs",
                schema: "Profiles");

            migrationBuilder.DropTable(
                name: "Skills",
                schema: "Profiles");

            migrationBuilder.DropTable(
                name: "Socials",
                schema: "Profiles");

            migrationBuilder.DropTable(
                name: "Resumes",
                schema: "Profiles");

            migrationBuilder.DropTable(
                name: "SpokenLanguages",
                schema: "Profiles");
        }
    }
}
