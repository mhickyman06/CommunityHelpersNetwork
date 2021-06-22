using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpersNetwork.Migrations
{
    public partial class updatingapplicationuserclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocalGovt",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EventModels",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePublished",
                value: new DateTime(2021, 6, 17, 20, 46, 42, 787, DateTimeKind.Local).AddTicks(8084));

            migrationBuilder.UpdateData(
                table: "EventModels",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatePublished",
                value: new DateTime(2021, 6, 17, 20, 46, 42, 788, DateTimeKind.Local).AddTicks(3905));

            migrationBuilder.UpdateData(
                table: "EventModels",
                keyColumn: "Id",
                keyValue: 3,
                column: "DatePublished",
                value: new DateTime(2021, 6, 17, 20, 46, 42, 788, DateTimeKind.Local).AddTicks(4076));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocalGovt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "EventModels",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePublished",
                value: new DateTime(2021, 6, 17, 14, 46, 14, 206, DateTimeKind.Local).AddTicks(7911));

            migrationBuilder.UpdateData(
                table: "EventModels",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatePublished",
                value: new DateTime(2021, 6, 17, 14, 46, 14, 207, DateTimeKind.Local).AddTicks(3394));

            migrationBuilder.UpdateData(
                table: "EventModels",
                keyColumn: "Id",
                keyValue: 3,
                column: "DatePublished",
                value: new DateTime(2021, 6, 17, 14, 46, 14, 207, DateTimeKind.Local).AddTicks(3547));
        }
    }
}
