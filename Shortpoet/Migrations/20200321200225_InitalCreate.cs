using Microsoft.EntityFrameworkCore.Migrations;

namespace Shortpoet.Migrations
{
    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Profile");

            migrationBuilder.CreateTable(
                name: "Resumes",
                schema: "Profile",
                columns: table => new
                {
                    ResumeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AboutMe = table.Column<string>(nullable: true),
                    Interests = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumes", x => x.ResumeId);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                schema: "Profile",
                columns: table => new
                {
                    EducationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumeId = table.Column<int>(nullable: true),
                    Institution = table.Column<string>(nullable: true),
                    Degree = table.Column<string>(nullable: true),
                    Focus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.EducationId);
                    table.ForeignKey(
                        name: "FK_Educations_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalSchema: "Profile",
                        principalTable: "Resumes",
                        principalColumn: "ResumeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                schema: "Profile",
                columns: table => new
                {
                    ExperienceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumeId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.ExperienceId);
                    table.ForeignKey(
                        name: "FK_Experiences_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalSchema: "Profile",
                        principalTable: "Resumes",
                        principalColumn: "ResumeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                schema: "Profile",
                columns: table => new
                {
                    SkillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumeId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                    table.ForeignKey(
                        name: "FK_Skills_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalSchema: "Profile",
                        principalTable: "Resumes",
                        principalColumn: "ResumeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpokenLanguages",
                schema: "Profile",
                columns: table => new
                {
                    SpokenLanguagesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumeId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Languages = table.Column<string>(nullable: true),
                    TranslationInterpretationProfessional = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpokenLanguages", x => x.SpokenLanguagesId);
                    table.ForeignKey(
                        name: "FK_SpokenLanguages_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalSchema: "Profile",
                        principalTable: "Resumes",
                        principalColumn: "ResumeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                schema: "Profile",
                columns: table => new
                {
                    JobId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumeId = table.Column<int>(nullable: true),
                    ExperienceId = table.Column<int>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StartDate = table.Column<string>(nullable: true),
                    EndDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_Jobs_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalSchema: "Profile",
                        principalTable: "Experiences",
                        principalColumn: "ExperienceId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Educations_ResumeId",
                schema: "Profile",
                table: "Educations",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_ResumeId",
                schema: "Profile",
                table: "Experiences",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ExperienceId",
                schema: "Profile",
                table: "Jobs",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ResumeId",
                schema: "Profile",
                table: "Skills",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpokenLanguages_ResumeId",
                schema: "Profile",
                table: "SpokenLanguages",
                column: "ResumeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Educations",
                schema: "Profile");

            migrationBuilder.DropTable(
                name: "Jobs",
                schema: "Profile");

            migrationBuilder.DropTable(
                name: "Skills",
                schema: "Profile");

            migrationBuilder.DropTable(
                name: "SpokenLanguages",
                schema: "Profile");

            migrationBuilder.DropTable(
                name: "Experiences",
                schema: "Profile");

            migrationBuilder.DropTable(
                name: "Resumes",
                schema: "Profile");
        }
    }
}
