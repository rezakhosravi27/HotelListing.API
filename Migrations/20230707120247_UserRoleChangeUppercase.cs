using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelListing.API.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleChangeUppercase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39b47d74-a818-4cb0-ab8c-cdc91fdf576f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2e4efca-afca-4514-a2c7-a40e9f3f589d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "99f27a32-9aab-48c0-b534-9a59b893bcd4", null, "User", "USER" },
                    { "db4afc97-c770-4f9a-90a7-e386555b7849", null, "adminstrator", "ADMINSTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99f27a32-9aab-48c0-b534-9a59b893bcd4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db4afc97-c770-4f9a-90a7-e386555b7849");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39b47d74-a818-4cb0-ab8c-cdc91fdf576f", null, "user", "USER" },
                    { "e2e4efca-afca-4514-a2c7-a40e9f3f589d", null, "adminstrator", "ADMINSTRATOR" }
                });
        }
    }
}
