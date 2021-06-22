using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpersNetwork.Migrations
{
    public partial class addeddatatodb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EventModels",
                columns: new[] { "Id", "Body", "DatePublished", "ImagePath", "PageTtile", "ShortDescription", "Title" },
                values: new object[] { 1, " Community Helpers Network is a faith based Non-Governmental Organisation that takes the   light of the church to the communityfor human capacity and infrastructure development. We also bring the community back to the church for personal and spiritual developments and interventions.", new DateTime(2021, 6, 17, 14, 46, 14, 206, DateTimeKind.Local).AddTicks(7911), "00000000-0000-0000-0000-000000000000HelpersHeadImage.jpg", "Ovalshape Moringa Tea", "Community Helpers Network is a faith based Non-Governmental Organisation that takes the light of the church ", "Ovalshape Nigeria presents Moringa Tea" });

            migrationBuilder.InsertData(
                table: "EventModels",
                columns: new[] { "Id", "Body", "DatePublished", "ImagePath", "PageTtile", "ShortDescription", "Title" },
                values: new object[] { 2, " Community Helpers Network is a faith based Non-Governmental Organisation that takes the   light of the church to the communityfor human capacity and infrastructure development. We also bring the community back to the church for personal and spiritual developments and interventions.", new DateTime(2021, 6, 17, 14, 46, 14, 207, DateTimeKind.Local).AddTicks(3394), "00000000-0000-0000-0000-000000000000HelpersHeadImage.jpg", "Ovalshape Moringa Tea", "Community Helpers Network is a faith based Non-Governmental Organisation that takes the light of the church ", "Ovalshape Nigeria presents Moringa Tea" });

            migrationBuilder.InsertData(
                table: "EventModels",
                columns: new[] { "Id", "Body", "DatePublished", "ImagePath", "PageTtile", "ShortDescription", "Title" },
                values: new object[] { 3, " Community Helpers Network is a faith based Non-Governmental Organisation that takes the   light of the church to the communityfor human capacity and infrastructure development. We also bring the community back to the church for personal and spiritual developments and interventions.", new DateTime(2021, 6, 17, 14, 46, 14, 207, DateTimeKind.Local).AddTicks(3547), "00000000-0000-0000-0000-000000000000HelpersHeadImage.jpg", "Ovalshape Moringa Tea", "Community Helpers Network is a faith based Non-Governmental Organisation that takes the light of the church ", "Ovalshape Nigeria presents Moringa Tea" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventModels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EventModels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EventModels",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
