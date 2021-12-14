using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Api.Data.Migrations
{
    public partial class Added_column_CuisineNationality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "751a9686-fcc0-431f-ae3c-193188a21c87");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82820396-17a1-4f8b-928d-49ea80ca3395");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd7c71c7-1ded-4fb1-ad85-089796b11b2c");

            migrationBuilder.AddColumn<int>(
                name: "CuisineNationalityId",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CuisineNationalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cuisine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuisineNationalities", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "355a1fa2-7f80-43e5-90f2-6846831c2238", "9c4ca7f2-5cf9-476a-a169-e2e95072accb", "Admin", "ADMIN" },
                    { "96cba3dd-68d3-4d4f-9b2c-fd7a3bc20857", "a5dd98a1-9885-45ad-a379-8fb483525ebe", "Manager", "MANAGER" },
                    { "c0102b53-9160-427f-b810-04a357e4363d", "8f097130-690b-49b1-8f3d-1df7cf2878f2", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "CuisineNationalities",
                columns: new[] { "Id", "Cuisine" },
                values: new object[,]
                {
                    { 1, null },
                    { 2, null },
                    { 3, null },
                    { 4, null },
                    { 5, null },
                    { 6, null },
                    { 7, null },
                    { 8, null },
                    { 9, null },
                    { 10, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CuisineNationalityId",
                table: "Articles",
                column: "CuisineNationalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_CuisineNationalities_CuisineNationalityId",
                table: "Articles",
                column: "CuisineNationalityId",
                principalTable: "CuisineNationalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_CuisineNationalities_CuisineNationalityId",
                table: "Articles");

            migrationBuilder.DropTable(
                name: "CuisineNationalities");

            migrationBuilder.DropIndex(
                name: "IX_Articles_CuisineNationalityId",
                table: "Articles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "355a1fa2-7f80-43e5-90f2-6846831c2238");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96cba3dd-68d3-4d4f-9b2c-fd7a3bc20857");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0102b53-9160-427f-b810-04a357e4363d");

            migrationBuilder.DropColumn(
                name: "CuisineNationalityId",
                table: "Articles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd7c71c7-1ded-4fb1-ad85-089796b11b2c", "9758ae62-21d9-4494-adcf-5fae090fd763", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "751a9686-fcc0-431f-ae3c-193188a21c87", "5a10b017-3a97-4019-8fcc-4a7f1edef3ef", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "82820396-17a1-4f8b-928d-49ea80ca3395", "84484210-64aa-46a4-ad71-8123fe12be6a", "User", "USER" });
        }
    }
}
