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
                name: "Educations",
                schema: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumeId = table.Column<int>(nullable: true),
                    Institution = table.Column<string>(nullable: true),
                    Degree = table.Column<string>(nullable: true),
                    Focus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educations_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalSchema: "Profiles",
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                schema: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumeId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiences_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalSchema: "Profiles",
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                schema: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumeId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalSchema: "Profiles",
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpokenLanguages",
                schema: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumeId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Languages = table.Column<string>(nullable: true),
                    TranslationInterpretationProfessional = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpokenLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpokenLanguages_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalSchema: "Profiles",
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                schema: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalSchema: "Profiles",
                        principalTable: "Experiences",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Educations_ResumeId",
                schema: "Profiles",
                table: "Educations",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_ResumeId",
                schema: "Profiles",
                table: "Experiences",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ExperienceId",
                schema: "Profiles",
                table: "Jobs",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ResumeId",
                schema: "Profiles",
                table: "Skills",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpokenLanguages_ResumeId",
                schema: "Profiles",
                table: "SpokenLanguages",
                column: "ResumeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "SpokenLanguages",
                schema: "Profiles");

            migrationBuilder.DropTable(
                name: "Experiences",
                schema: "Profiles");

            migrationBuilder.DropTable(
                name: "Resumes",
                schema: "Profiles");
        }
    }
}
