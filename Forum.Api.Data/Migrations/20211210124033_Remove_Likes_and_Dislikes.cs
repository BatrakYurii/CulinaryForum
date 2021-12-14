using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Api.Data.Migrations
{
    public partial class Remove_Likes_and_Dislikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Dislikes",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Articles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "19db5dd7-ced3-4f7e-92bc-0dfaca0b47fb", "68e5f137-d14e-4fae-b508-d9d5439a5df7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0fc7e610-dad3-4d12-b2c6-480fbfa097ef", "2e6ade3f-84c7-41bc-85ae-fe72ffd91244", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "04fe43b6-ba15-4f5a-bbd0-3bea1e1094c7", "07153388-9919-407b-a6bc-72a027722fa3", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04fe43b6-ba15-4f5a-bbd0-3bea1e1094c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0fc7e610-dad3-4d12-b2c6-480fbfa097ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19db5dd7-ced3-4f7e-92bc-0dfaca0b47fb");

            migrationBuilder.AddColumn<int>(
                name: "Dislikes",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
