using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Api.Data.Migrations
{
    public partial class Change_CookingTime_type_property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "035d4ed1-a7ee-4869-adbc-c02cdbc1d40a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b221b9e-7160-4541-b68b-662357913bee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f759f2f-d24f-4296-9efb-46973c1a2a29");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0517402f-5d51-45f6-ad3a-f855358fc6fd", "170b13a2-2f9c-4aba-8683-dd389276f0eb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "603ac7be-a0bd-4ac4-a8bf-d165cca6b65d", "d91bc678-cf01-4ee8-9f79-d257b6cbe49b", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ee9af3e2-443a-42bc-8813-5b903a6ed504", "c27e3c1a-f05f-4f61-bfaa-6ee224a4d1e5", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0517402f-5d51-45f6-ad3a-f855358fc6fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "603ac7be-a0bd-4ac4-a8bf-d165cca6b65d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee9af3e2-443a-42bc-8813-5b903a6ed504");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "035d4ed1-a7ee-4869-adbc-c02cdbc1d40a", "4805f12c-bf99-4a9f-9dfd-67d4483ca65f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7f759f2f-d24f-4296-9efb-46973c1a2a29", "eff76f4f-e538-4f0e-895a-0434bcf88bf4", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5b221b9e-7160-4541-b68b-662357913bee", "409398e3-3be6-4aae-bf0f-071c1c590bfe", "User", "USER" });
        }
    }
}
