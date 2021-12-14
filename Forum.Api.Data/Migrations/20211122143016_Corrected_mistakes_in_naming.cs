using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Api.Data.Migrations
{
    public partial class Corrected_mistakes_in_naming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cb6a6b5-c555-4233-bb3f-fafc6e7d44e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8074a251-2b71-43d0-80d9-8ae03963a15e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3cb271e-aac2-4fea-b463-645801374d25");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b2900713-0df6-4fcf-ad82-e4512d45d40a", "28d713b9-d053-4389-a968-6249c019758e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0443af96-9aea-4e32-bc6f-8248cc901c27", "c4ed70ba-2f80-4e67-be18-7741d47dbb6c", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "69176da9-1e9f-4dde-a417-72a45f38bf0a", "6c8cf3c9-ab0e-4172-9239-ad4d0bfbbb8c", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0443af96-9aea-4e32-bc6f-8248cc901c27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69176da9-1e9f-4dde-a417-72a45f38bf0a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2900713-0df6-4fcf-ad82-e4512d45d40a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a3cb271e-aac2-4fea-b463-645801374d25", "58023b6e-ddc5-4f82-9ce2-dfff8f27d625", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8074a251-2b71-43d0-80d9-8ae03963a15e", "1ac8376c-6c54-49c9-9324-a755067ce89c", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7cb6a6b5-c555-4233-bb3f-fafc6e7d44e3", "9de70855-19ed-4faf-b1d0-0db847de4339", "User", "USER" });
        }
    }
}
