using Microsoft.EntityFrameworkCore.Migrations;

namespace Promocodes.Data.Persistence.Migrations
{
    public partial class AddAdminsToShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopAdmins_Shops_ShopId",
                table: "ShopAdmins");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopAdmins_Shops_ShopId",
                table: "ShopAdmins",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopAdmins_Shops_ShopId",
                table: "ShopAdmins");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopAdmins_Shops_ShopId",
                table: "ShopAdmins",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
