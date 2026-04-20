using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StuWare.Data.Migrations
{
    public partial class AddPanelUpdatedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Panel",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Panel");
        }
    }
}
