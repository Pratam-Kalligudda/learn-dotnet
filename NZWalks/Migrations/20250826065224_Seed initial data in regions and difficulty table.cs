using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.Migrations
{
    /// <inheritdoc />
    public partial class Seedinitialdatainregionsanddifficultytable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("28c8b650-dee4-44a1-a3a1-ddc90377faeb"), "Easy" },
                    { new Guid("64662286-6321-45da-b36f-3def20384738"), "Hard" },
                    { new Guid("e70d9a02-eed6-435f-a9c9-300f70d6656a"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageURL" },
                values: new object[,]
                {
                    { new Guid("152f4b1a-4f66-4d49-b375-d736854e4138"), "STL", "SouthLand", null },
                    { new Guid("2e042307-2f33-4642-9321-ed3fc637bb4e"), "BOP", "Bay of Plenty", null },
                    { new Guid("511bc335-a23b-4cd2-bc3a-aefc03568811"), "WGN", "Wellington", "https://images.pexels.com/photos/3709402/pexels-photo-3709402.jpeg" },
                    { new Guid("7b3eb59b-ff49-4a74-97fe-2e03705b21e7"), "AKL", "Auckland", "https://images.pexels.com/photos/33602901/pexels-photo-33602901.jpeg" },
                    { new Guid("9a60fca5-8c43-41c5-95e2-c00b69908230"), "NSN", "Nelson", "https://images.pexels.com/photos/3396661/pexels-photo-3396661.jpeg" },
                    { new Guid("e6e76066-9f9c-4514-8b18-21244bfaa6e6"), "NTL", "Northland", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("28c8b650-dee4-44a1-a3a1-ddc90377faeb"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("64662286-6321-45da-b36f-3def20384738"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("e70d9a02-eed6-435f-a9c9-300f70d6656a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("152f4b1a-4f66-4d49-b375-d736854e4138"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("2e042307-2f33-4642-9321-ed3fc637bb4e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("511bc335-a23b-4cd2-bc3a-aefc03568811"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7b3eb59b-ff49-4a74-97fe-2e03705b21e7"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("9a60fca5-8c43-41c5-95e2-c00b69908230"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e6e76066-9f9c-4514-8b18-21244bfaa6e6"));
        }
    }
}
