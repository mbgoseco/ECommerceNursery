using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NurseryApp.Migrations.NurseryDb
{
    public partial class nurserymig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Checkouts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<string>(nullable: true),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkouts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Img = table.Column<string>(nullable: true),
                    Sku = table.Column<string>(nullable: true),
                    Bulk = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BasketProducts",
                columns: table => new
                {
                    BasketID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketProducts", x => new { x.BasketID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_BasketProducts_Baskets_BasketID",
                        column: x => x.BasketID,
                        principalTable: "Baskets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketProducts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckoutProducts",
                columns: table => new
                {
                    CheckoutID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutProducts", x => new { x.CheckoutID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_CheckoutProducts_Checkouts_CheckoutID",
                        column: x => x.CheckoutID,
                        principalTable: "Checkouts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckoutProducts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Bulk", "Description", "Img", "Name", "Price", "Quantity", "Sku", "Type" },
                values: new object[,]
                {
                    { 1, false, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Ranier Cherry Tree", 1.00m, 0, "abcdef", 0 },
                    { 18, true, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Magestic Palm - Bulk", 1.00m, 0, "9d9emd", 3 },
                    { 17, true, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Echivera- Bulk", 1.00m, 0, "zxcv34", 3 },
                    { 16, true, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Red Raspberry - Bulk", 1.00m, 0, "098lkjh", 1 },
                    { 15, true, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Dwarf Plum Tree - Bulk", 1.00m, 0, "567ghj", 0 },
                    { 14, true, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Dwarf Apple Tree - Bulk", 1.00m, 0, "yuiop", 0 },
                    { 13, true, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Rhododendron - Bulk", 1.00m, 0, "123345", 1 },
                    { 12, true, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Yoshino Cherry Tree - Bulk", 1.00m, 0, "qwerty", 0 },
                    { 11, true, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Ranier Cherry Tree - Bulk", 1.00m, 0, "abcdef", 0 },
                    { 10, false, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Giant Sunflower", 1.00m, 0, "abci876k", 2 },
                    { 9, false, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "California Black Oak", 1.00m, 0, "098asdf", 0 },
                    { 8, false, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Magestic Palm", 1.00m, 0, "9d9emd", 3 },
                    { 7, false, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Echivera", 1.00m, 0, "zxcv34", 3 },
                    { 6, false, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Red Raspberry", 1.00m, 0, "098lkjh", 1 },
                    { 5, false, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Dwarf Plum Tree", 1.00m, 0, "567ghj", 0 },
                    { 4, false, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Dwarf Apple Tree", 1.00m, 0, "yuiop", 0 },
                    { 3, false, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Rhododendron", 1.00m, 0, "123345", 1 },
                    { 2, false, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Yoshino Cherry Tree", 1.00m, 0, "qwerty", 0 },
                    { 19, true, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "California Black Oak - Bulk", 1.00m, 0, "098asdf", 0 },
                    { 20, true, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Giant Sunflower - Bulk", 1.00m, 0, "abci876k", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketProducts_ProductID",
                table: "BasketProducts",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutProducts_ProductID",
                table: "CheckoutProducts",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketProducts");

            migrationBuilder.DropTable(
                name: "CheckoutProducts");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Checkouts");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
