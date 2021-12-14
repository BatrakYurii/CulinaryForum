using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Api.Data.Migrations
{
    public partial class Added_property_AvatarImage_to_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "AvatarImage",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarImage",
                table: "AspNetUsers");

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
    }
}
