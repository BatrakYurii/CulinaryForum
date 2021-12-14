using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Api.Data.Migrations
{
    public partial class Corrected_sytacsis_mistakes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticlesCategories_Categories_CategoryId",
                table: "ArticlesCategories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41417fa7-ae00-4f60-8687-6f8df5068c54");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0da687f-491a-4282-81dc-ade48a4fe3f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5d601aa-1090-4061-8913-b9100e94af8b");

            migrationBuilder.DropColumn(
                name: "CaregoryId",
                table: "ArticlesCategories");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "ArticlesCategories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c30048c6-3796-45fc-95e6-ecda787076d8", "6d2c3138-d19c-4814-b4bc-76e0025afcaa", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "47ad4d5e-a770-4dcf-ba6f-ecaa01e24d05", "4fa3272a-2140-4c5e-8216-00dc666d4edc", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "76bd00ea-48a6-423f-95a6-a99f52f4054c", "7343f4ba-6aeb-4eca-be21-464fa38b1d88", "User", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_ArticlesCategories_Categories_CategoryId",
                table: "ArticlesCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticlesCategories_Categories_CategoryId",
                table: "ArticlesCategories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47ad4d5e-a770-4dcf-ba6f-ecaa01e24d05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76bd00ea-48a6-423f-95a6-a99f52f4054c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c30048c6-3796-45fc-95e6-ecda787076d8");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "ArticlesCategories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CaregoryId",
                table: "ArticlesCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "41417fa7-ae00-4f60-8687-6f8df5068c54", "1e1d33e9-0cc2-4470-aa20-4f469a6e18b8", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5d601aa-1090-4061-8913-b9100e94af8b", "e7831395-ef02-4ef0-aec0-b83819174006", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b0da687f-491a-4282-81dc-ade48a4fe3f1", "a123836d-cea1-48c1-8695-12007479ada5", "User", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_ArticlesCategories_Categories_CategoryId",
                table: "ArticlesCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
