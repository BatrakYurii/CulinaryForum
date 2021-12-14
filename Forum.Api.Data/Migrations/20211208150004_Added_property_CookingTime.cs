using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Api.Data.Migrations
{
    public partial class Added_property_CookingTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "909c0fa3-7b66-4390-84c9-f5e34e769c86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3e02315-8710-4a0e-82da-cfc3719cccf2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db03ab4f-d849-42ec-9df9-69f4a78573de");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "CookingTime",
                table: "Articles",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d586b5fc-1e8e-46a4-8f74-09908224d2bf", "9631fcf7-0a53-4f46-bbc1-e41ab1a46f7d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "486ef40b-31fa-4ea3-9613-38cc63320e26", "cea4420f-3a7e-4a02-9097-8f4001ade370", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a1aaa267-c0bd-4221-82a2-c8b94be0de8c", "26c2a21e-b456-4ef4-a93f-ff4a0b6da629", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "486ef40b-31fa-4ea3-9613-38cc63320e26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1aaa267-c0bd-4221-82a2-c8b94be0de8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d586b5fc-1e8e-46a4-8f74-09908224d2bf");

            migrationBuilder.DropColumn(
                name: "CookingTime",
                table: "Articles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "909c0fa3-7b66-4390-84c9-f5e34e769c86", "14aa34f7-ee55-45de-85b1-595e488ed288", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a3e02315-8710-4a0e-82da-cfc3719cccf2", "85ca64ff-eb6b-4855-8e89-592ae23dfad3", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "db03ab4f-d849-42ec-9df9-69f4a78573de", "f46f3c91-95f9-4b67-bcbf-058a40226fb8", "User", "USER" });
        }
    }
}
