using Microsoft.EntityFrameworkCore.Migrations;

namespace Promocodes.Data.Persistence.Migrations
{
    public partial class RemoveRatingFromShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Shops");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "Shops",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
