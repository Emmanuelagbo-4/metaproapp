using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace metaproapp.Migrations
{
    public partial class updateTeamsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Teams");
        }
    }
}
