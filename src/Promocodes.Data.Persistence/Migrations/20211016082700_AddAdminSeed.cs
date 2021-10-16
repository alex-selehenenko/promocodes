using Microsoft.EntityFrameworkCore.Migrations;

namespace Promocodes.Data.Persistence.Migrations
{
    public partial class AddAdminSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Phone", "UserName" },
                values: new object[] { 6, "+30632526897", "Andrew Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Phone", "UserName" },
                values: new object[] { 7, "+30632526899", "Ben Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Phone", "UserName" },
                values: new object[] { 8, "+30632526890", "Alicia Admin" });

            migrationBuilder.InsertData(
                table: "ShopAdmins",
                columns: new[] { "Id", "ShopId" },
                values: new object[] { 6, 1 });

            migrationBuilder.InsertData(
                table: "ShopAdmins",
                columns: new[] { "Id", "ShopId" },
                values: new object[] { 7, 1 });

            migrationBuilder.InsertData(
                table: "ShopAdmins",
                columns: new[] { "Id", "ShopId" },
                values: new object[] { 8, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShopAdmins",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ShopAdmins",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ShopAdmins",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
