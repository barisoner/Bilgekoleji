using Microsoft.EntityFrameworkCore.Migrations;

namespace StuWare.Data.Migrations
{
    public partial class period : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "StudentLessonGrade",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "StudentLessonGrade");
        }
    }
}
