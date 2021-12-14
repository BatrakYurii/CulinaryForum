using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Api.Data.Migrations
{
    public partial class fix_roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "035d4ed1-a7ee-4869-adbc-c02cdbc1d40a", "4805f12c-bf99-4a9f-9dfd-67d4483ca65f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7f759f2f-d24f-4296-9efb-46973c1a2a29", "eff76f4f-e538-4f0e-895a-0434bcf88bf4", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5b221b9e-7160-4541-b68b-662357913bee", "409398e3-3be6-4aae-bf0f-071c1c590bfe", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "035d4ed1-a7ee-4869-adbc-c02cdbc1d40a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b221b9e-7160-4541-b68b-662357913bee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f759f2f-d24f-4296-9efb-46973c1a2a29");
        }
    }
}
