using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Api.Data.Migrations
{
    public partial class fix_datetime_bag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "CookingTime",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "CookingTime",
                table: "Articles",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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
    }
}
