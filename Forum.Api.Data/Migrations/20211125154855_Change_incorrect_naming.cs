using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Api.Data.Migrations
{
    public partial class Change_incorrect_naming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47ad4d5e-a770-4dcf-ba6f-ecaa01e24d05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76bd00ea-48a6-423f-95a6-a99f52f4054c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c30048c6-3796-45fc-95e6-ecda787076d8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "80eeeec3-fc75-40e4-8416-3f215c8debfb", "00e0c159-1d48-4f8c-a1e6-b051a211c867", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6dfd508b-f24d-435c-81be-c5ddf66d9ea8", "56909762-36e4-41e7-af0e-8d64b0b37046", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "716b6400-0a6e-4aae-8e29-0a49e8779ef5", "53cf9134-9b3a-4592-ac0f-29e75c1b9fed", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6dfd508b-f24d-435c-81be-c5ddf66d9ea8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "716b6400-0a6e-4aae-8e29-0a49e8779ef5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80eeeec3-fc75-40e4-8416-3f215c8debfb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c30048c6-3796-45fc-95e6-ecda787076d8", "6d2c3138-d19c-4814-b4bc-76e0025afcaa", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "47ad4d5e-a770-4dcf-ba6f-ecaa01e24d05", "4fa3272a-2140-4c5e-8216-00dc666d4edc", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "76bd00ea-48a6-423f-95a6-a99f52f4054c", "7343f4ba-6aeb-4eca-be21-464fa38b1d88", "User", "USER" });
        }
    }
}
