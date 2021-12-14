using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Api.Data.Migrations
{
    public partial class Add_atribute_Ignore_in_comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e622fae-b10a-4bf2-8475-12cc6ee91555");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96ec2d36-3f3c-4d82-b040-aafa27cab75e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ae0ebc5-206e-47f7-a20f-2d061171706c");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "96ec2d36-3f3c-4d82-b040-aafa27cab75e", "0554a566-58bb-4eac-8437-38f02a686477", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8e622fae-b10a-4bf2-8475-12cc6ee91555", "4be72577-22d8-493a-bd9e-5cfbcd8e13ad", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9ae0ebc5-206e-47f7-a20f-2d061171706c", "11e27a27-847f-4371-8b01-68c14e945b38", "User", "USER" });
        }
    }
}
