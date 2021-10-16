using Microsoft.EntityFrameworkCore.Migrations;

namespace Promocodes.Data.Persistence.Migrations
{
    public partial class Issue19_AddCustomerSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Phone", "UserName" },
                values: new object[,]
                {
                    { 1, "+380631111111", "alex" },
                    { 2, "+380632222222", "serg" },
                    { 3, "+380633333333", "jess" },
                    { 4, "+380634444444", "qwerty" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                column: "Id",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
