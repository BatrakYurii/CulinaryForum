using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Api.Data.Migrations
{
    public partial class Ghange_datatype_for_User_in_Comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId1",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6dfd508b-f24d-435c-81be-c5ddf66d9ea8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "716b6400-0a6e-4aae-8e29-0a49e8779ef5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80eeeec3-fc75-40e4-8416-3f215c8debfb");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "479ffb02-8efb-42b7-871d-8f24fabc79c1", "3133e3f6-0671-453d-911d-8f332c4e1ee4", "Admin", "ADMIN" },
                    { "5a664f5d-544d-4732-8acd-4bf58380b2f6", "9814a401-090c-4c94-9fe7-ef33b637d9fd", "Manager", "MANAGER" },
                    { "9c6d8b55-68c2-44e5-8d6b-0f431ad2a51c", "675070cf-c2b7-4e3e-8076-7e88228afac1", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "CuisineNationalities",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nationality",
                value: "Индонезийская кухня");

            migrationBuilder.UpdateData(
                table: "CuisineNationalities",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nationality",
                value: "Мексиканская кухня");

            migrationBuilder.UpdateData(
                table: "CuisineNationalities",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nationality",
                value: "Китайская кухня");

            migrationBuilder.UpdateData(
                table: "CuisineNationalities",
                keyColumn: "Id",
                keyValue: 4,
                column: "Nationality",
                value: "Итальянская кухня");

            migrationBuilder.UpdateData(
                table: "CuisineNationalities",
                keyColumn: "Id",
                keyValue: 5,
                column: "Nationality",
                value: "Испанская кухня");

            migrationBuilder.UpdateData(
                table: "CuisineNationalities",
                keyColumn: "Id",
                keyValue: 6,
                column: "Nationality",
                value: "Французкая кухня");

            migrationBuilder.UpdateData(
                table: "CuisineNationalities",
                keyColumn: "Id",
                keyValue: 7,
                column: "Nationality",
                value: "Японская кухня");

            migrationBuilder.UpdateData(
                table: "CuisineNationalities",
                keyColumn: "Id",
                keyValue: 8,
                column: "Nationality",
                value: "Индийская кухня");

            migrationBuilder.UpdateData(
                table: "CuisineNationalities",
                keyColumn: "Id",
                keyValue: 9,
                column: "Nationality",
                value: "Украинская кухня");

            migrationBuilder.UpdateData(
                table: "CuisineNationalities",
                keyColumn: "Id",
                keyValue: 10,
                column: "Nationality",
                value: "Русская кухня");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "479ffb02-8efb-42b7-871d-8f24fabc79c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a664f5d-544d-4732-8acd-4bf58380b2f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c6d8b55-68c2-44e5-8d6b-0f431ad2a51c");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "80eeeec3-fc75-40e4-8416-3f215c8debfb", "00e0c159-1d48-4f8c-a1e6-b051a211c867", "Admin", "ADMIN" },
                    { "6dfd508b-f24d-435c-81be-c5ddf66d9ea8", "56909762-36e4-41e7-af0e-8d64b0b37046", "Manager", "MANAGER" },
                    { "716b6400-0a6e-4aae-8e29-0a49e8779ef5", "53cf9134-9b3a-4592-ac0f-29e75c1b9fed", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "CuisineNationalities",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nationality",
                value: null);

            migrationBuilder.UpdateData(
                table: "CuisineNationalities",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nationality",
                value: null);

            migrationBuilder.UpdateData(
                table: "CuisineNationalities",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nationality",
                value: null);

            migrationBuilder.UpdateData(
                table: "CuisineNationalities",
                keyColumn: "Id",
                keyValue: 4,
                column: "Nationality",
                value: null);

            migrationBuilder.UpdateData(
                table: "CuisineNationalities",
                keyColumn: "Id",
                keyValue: 5,
                column: "Nationality",
                value: null);

            migrationBuilder.UpdateData(
                table: "CuisineNationalities",
                keyColumn: "Id",
                keyValue: 6,
                column: "Nationality",
                value: null);

            migrationBuilder.UpdateData(
                table: "CuisineNationalities",
                keyColumn: "Id",
                keyValue: 7,
                column: "Nationality",
                value: null);

            migrationBuilder.UpdateData(
                table: "CuisineNationalities",
                keyColumn: "Id",
                keyValue: 8,
                column: "Nationality",
                value: null);

            migrationBuilder.UpdateData(
                table: "CuisineNationalities",
                keyColumn: "Id",
                keyValue: 9,
                column: "Nationality",
                value: null);

            migrationBuilder.UpdateData(
                table: "CuisineNationalities",
                keyColumn: "Id",
                keyValue: 10,
                column: "Nationality",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId1",
                table: "Comments",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId1",
                table: "Comments",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
