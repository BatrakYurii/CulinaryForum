using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Api.Data.Migrations
{
    public partial class Added_property_IsVegan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63d0aff4-ad71-472d-b175-956ac8f8ebc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99bf1226-3be5-414c-9ccc-b93e558b66af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ff3c0da-dd96-4926-ab74-8d9256b9236b");

            migrationBuilder.AddColumn<bool>(
                name: "IsVegan",
                table: "Articles",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsVegan",
                table: "Articles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "63d0aff4-ad71-472d-b175-956ac8f8ebc2", "3f741d19-7348-4226-ae72-a65a7c578d8c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99bf1226-3be5-414c-9ccc-b93e558b66af", "ca773677-0f08-41c3-80ec-0591af437e18", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9ff3c0da-dd96-4926-ab74-8d9256b9236b", "0cf1d016-5462-474f-9032-99eb88c871e5", "User", "USER" });
        }
    }
}
