using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Promocodes.Data.Persistence.Migrations
{
    public partial class RefreshDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Site = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryShop",
                columns: table => new
                {
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryShop", x => new { x.ShopId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_CategoryShop_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryShop_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Promocode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopAdmins",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopAdmins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopAdmins_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    OfferId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Baby" },
                    { 3, "Clothes" }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Description", "Name", "Site" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit", "Electron Plus", "https://eee-plus.com.ua" },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit", "Baby boom", "https://b-a-b-y-boom.com.ua" },
                    { 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit", "Zebra", "https://zebrrra.biz.ua" }
                });

            migrationBuilder.InsertData(
                table: "CategoryShop",
                columns: new[] { "CategoryId", "ShopId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Description", "Discount", "ExpirationDate", "IsDeleted", "IsEnabled", "Promocode", "ShopId", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, "Get 30% discount!", 0.3f, new DateTime(2021, 11, 29, 14, 40, 55, 442, DateTimeKind.Local).AddTicks(6748), false, true, "OCTOBER", 1, new DateTime(2021, 10, 30, 14, 40, 55, 441, DateTimeKind.Local).AddTicks(6615), "Electron Plus October GRAND SALE" },
                    { 2, "Hurry up to get 70% discount on TOYS!", 0.7f, new DateTime(2021, 11, 9, 14, 40, 55, 442, DateTimeKind.Local).AddTicks(7920), false, true, "OCTOBER", 2, new DateTime(2021, 10, 30, 14, 40, 55, 442, DateTimeKind.Local).AddTicks(7914), "Baby Boom FRESH discount" },
                    { 3, "Get 50% discount on summer collection!", 0.5f, new DateTime(2021, 11, 29, 14, 40, 55, 442, DateTimeKind.Local).AddTicks(7928), false, true, "OCTOBER", 3, new DateTime(2021, 10, 30, 14, 40, 55, 442, DateTimeKind.Local).AddTicks(7927), "Zebra SALE" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CreationTime", "LastUpdateTime", "ShopId", "Stars", "Text", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 10, 30, 14, 40, 55, 443, DateTimeKind.Local).AddTicks(4854), new DateTime(2021, 10, 30, 14, 40, 55, 444, DateTimeKind.Local).AddTicks(4860), 1, 10, "Very good shop!", "698306d9-4478-4a58-8b38-b547e85e2289" },
                    { 2, new DateTime(2021, 10, 30, 14, 40, 55, 443, DateTimeKind.Local).AddTicks(4872), new DateTime(2021, 10, 30, 14, 40, 55, 444, DateTimeKind.Local).AddTicks(4873), 2, 8, "Like baby boom. But delivery taskes a wile", "698306d9-4478-4a58-8b38-b547e85e2289" },
                    { 3, new DateTime(2021, 10, 30, 14, 40, 55, 443, DateTimeKind.Local).AddTicks(5775), new DateTime(2021, 10, 30, 14, 40, 55, 444, DateTimeKind.Local).AddTicks(5778), 3, 1, "Awful service!", "698306d9-4478-4a58-8b38-b547e85e2289" },
                    { 4, new DateTime(2021, 10, 30, 14, 40, 55, 443, DateTimeKind.Local).AddTicks(5781), new DateTime(2021, 10, 30, 14, 40, 55, 444, DateTimeKind.Local).AddTicks(5782), 3, 9, "Excellent!", "82b4753f-8f7f-43d1-a67d-13b531d9512b" }
                });

            migrationBuilder.InsertData(
                table: "ShopAdmins",
                columns: new[] { "Id", "ShopId" },
                values: new object[,]
                {
                    { "e71a1ef0-fcdc-4069-87bb-2b38bdde23ac", 1 },
                    { "b466992a-5ad2-4f8b-ab92-cd1abbbe22e9", 2 },
                    { "766fdfbf-119d-45f7-a148-995bbe1009d0", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryShop_CategoryId",
                table: "CategoryShop",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_OfferId",
                table: "Customers",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ShopId",
                table: "Offers",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ShopId",
                table: "Reviews",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopAdmins_ShopId",
                table: "ShopAdmins",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "UQ_Shop_Name",
                table: "Shops",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryShop");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "ShopAdmins");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}
