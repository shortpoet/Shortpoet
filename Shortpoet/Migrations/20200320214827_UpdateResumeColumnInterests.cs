using Microsoft.EntityFrameworkCore.Migrations;

namespace Shortpoet.Migrations
{
    public partial class UpdateResumeColumnInterests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Interests",
                schema: "Profile",
                table: "Resumes",
                nullable: true);
            // below not part of original migration
            // i thought i could change it
            // turns out that's pretty tough and sounds like an anti-pattern
            // https://stackoverflow.com/questions/21951697/how-to-edit-previously-applied-migration-without-adding-another-migration-in-ef
            // this inserts new row with nulls accross rest of cols
            // migrationBuilder.InsertData(
            //     table: "Resumes",
            //     schema: "Profile",
            //     column: "Interests",
            //     values: new object[] { "Cooking, organic gardening, yoga, health and fitness, scuba diving, voiceovers, acting" });
            // migrationBuilder.InsertData("Resumes", "Interests", new object[] { "Cooking, organic gardening, yoga, health and fitness, scuba diving, voiceovers, acting" }, "Profile")
            migrationBuilder.Sql($"UPDATE Profile.Resumes SET Interests = 'Cooking, organic gardening, yoga, health and fitness, scuba diving, voiceovers, acting' WHERE ResumeId = 1");
            // migrationBuilder.Sql($"UPDATE Profile.Resume SET Interests = 'Cooking, organic gardening, yoga, health and fitness, scuba diving, voiceovers, acting' WHERE Interests = NULL");
        }
        

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Interests",
                schema: "Profile",
                table: "Resumes");
        }
    }
}
