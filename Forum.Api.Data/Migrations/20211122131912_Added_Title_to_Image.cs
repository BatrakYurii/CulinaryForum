using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Api.Data.Migrations
{
    public partial class Added_Title_to_Image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d7363b5-4dcb-4513-a76f-a8816090aaca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65d0df66-b17f-4066-ad8c-62cf9558af47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a921d271-6116-445d-8227-a97f14b9d462");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Images");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "65d0df66-b17f-4066-ad8c-62cf9558af47", "e3ffb5a4-d096-4403-98ec-371c3c6a4480", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a921d271-6116-445d-8227-a97f14b9d462", "5efc707e-e61c-40de-be0d-773271302386", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d7363b5-4dcb-4513-a76f-a8816090aaca", "d70b9139-cd6c-47ea-81dc-c7fa0bcf7570", "User", "USER" });
        }
    }
}
