using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpersNetwork.Migrations
{
    public partial class addingdatatogallery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.InsertData(
                table: "ProjectGalleries",
                columns: new[] { "Id", "DatePublished", "ImagePath", "ImageTitle" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 6, 21, 13, 27, 55, 678, DateTimeKind.Local).AddTicks(3586), "galery-img2.jpg", "Capured  during the meeting" },
                    { 2, new DateTime(2021, 6, 21, 13, 27, 55, 678, DateTimeKind.Local).AddTicks(5821), "galery-img3.jpg", "Capured  during the meeting" },
                    { 3, new DateTime(2021, 6, 21, 13, 27, 55, 678, DateTimeKind.Local).AddTicks(5896), "galery-img5.jpg", "Capured  during the meeting" },
                    { 4, new DateTime(2021, 6, 21, 13, 27, 55, 678, DateTimeKind.Local).AddTicks(5904), "galery-img6.jpg", "Capured  during the meeting" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectGalleries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProjectGalleries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProjectGalleries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProjectGalleries",
                keyColumn: "Id",
                keyValue: 4);       
        }
    }
}
