using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpersNetwork.Migrations
{
    public partial class addingcomunityprojectmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body",
                table: "communityLatestProjects");

            migrationBuilder.DropColumn(
                name: "ProjectTitle",
                table: "communityLatestProjects");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "communityLatestProjects");

            migrationBuilder.AlterColumn<string>(
                name: "DatePublished",
                table: "communityLatestProjects",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePublished",
                table: "communityLatestProjects",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "communityLatestProjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjectTitle",
                table: "communityLatestProjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "communityLatestProjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
