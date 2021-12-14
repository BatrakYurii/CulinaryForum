using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Api.Data.Migrations
{
    public partial class Cange_Image_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_UserId1",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_UserId1",
                table: "Articles");

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

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Articles");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Articles",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_UserId",
                table: "Articles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_UserId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_UserId",
                table: "Articles");

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

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Articles",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId1",
                table: "Articles",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_UserId1",
                table: "Articles",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
