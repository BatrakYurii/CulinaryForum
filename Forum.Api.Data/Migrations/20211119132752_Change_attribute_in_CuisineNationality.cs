using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Api.Data.Migrations
{
    public partial class Change_attribute_in_CuisineNationality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "355a1fa2-7f80-43e5-90f2-6846831c2238");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96cba3dd-68d3-4d4f-9b2c-fd7a3bc20857");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0102b53-9160-427f-b810-04a357e4363d");

            migrationBuilder.RenameColumn(
                name: "Cuisine",
                table: "CuisineNationalities",
                newName: "Nationality");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "65d0df66-b17f-4066-ad8c-62cf9558af47", "e3ffb5a4-d096-4403-98ec-371c3c6a4480", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a921d271-6116-445d-8227-a97f14b9d462", "5efc707e-e61c-40de-be0d-773271302386", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d7363b5-4dcb-4513-a76f-a8816090aaca", "d70b9139-cd6c-47ea-81dc-c7fa0bcf7570", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d7363b5-4dcb-4513-a76f-a8816090aaca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65d0df66-b17f-4066-ad8c-62cf9558af47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a921d271-6116-445d-8227-a97f14b9d462");

            migrationBuilder.RenameColumn(
                name: "Nationality",
                table: "CuisineNationalities",
                newName: "Cuisine");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "355a1fa2-7f80-43e5-90f2-6846831c2238", "9c4ca7f2-5cf9-476a-a169-e2e95072accb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "96cba3dd-68d3-4d4f-9b2c-fd7a3bc20857", "a5dd98a1-9885-45ad-a379-8fb483525ebe", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c0102b53-9160-427f-b810-04a357e4363d", "8f097130-690b-49b1-8f3d-1df7cf2878f2", "User", "USER" });
        }
    }
}
