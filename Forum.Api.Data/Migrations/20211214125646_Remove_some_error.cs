using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Api.Data.Migrations
{
    public partial class Remove_some_error : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2175b86-ff42-45d0-96f5-21835e1a2fb0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8faeb69-8c3e-4418-a56c-7be9f8d4f15b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2cff89f-789c-4f15-9a41-ab3b5fb238ac");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fb68540d-c59d-42d6-a187-1de7064f1f99", "673ad90b-b643-4c41-8637-a616514685ae", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f2ddff3a-f6ef-407d-862e-1194aefc0599", "25feebb6-dac9-4152-b0f6-96b0edd51bf0", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e92974fb-5319-4620-a2f4-a27ec331b5bf", "9e1f2515-9f17-4514-a795-87aa2425f073", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e92974fb-5319-4620-a2f4-a27ec331b5bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2ddff3a-f6ef-407d-862e-1194aefc0599");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb68540d-c59d-42d6-a187-1de7064f1f99");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c2175b86-ff42-45d0-96f5-21835e1a2fb0", "6b0cddd9-59df-4078-8b63-6763bb6e3943", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d8faeb69-8c3e-4418-a56c-7be9f8d4f15b", "70fddaf9-43df-4c10-857f-4a3e2b09f5d2", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f2cff89f-789c-4f15-9a41-ab3b5fb238ac", "4bc35b5c-9360-4d00-8dac-9b0cde6be103", "User", "USER" });
        }
    }
}
