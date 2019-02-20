using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NurseryApp.Migrations
{
    public partial class seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Img = table.Column<string>(nullable: true),
                    Sku = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Img", "Name", "Price", "Sku", "Type" },
                values: new object[,]
                {
                    { 1, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Ranier Cherry Tree", 1.00m, "abcdef", 0 },
                    { 2, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Yoshino Cherry Tree", 1.00m, "qwerty", 0 },
                    { 3, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Rhododendron", 1.00m, "123345", 1 },
                    { 4, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Dwarf Apple Tree", 1.00m, "yuiop", 0 },
                    { 5, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Dwarf Plum Tree", 1.00m, "567ghj", 0 },
                    { 6, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Red Raspberry", 1.00m, "098lkjh", 1 },
                    { 7, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Echivera", 1.00m, "zxcv34", 3 },
                    { 8, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Magestic Palm", 1.00m, "9d9emd", 3 },
                    { 9, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "California Black Oak", 1.00m, "098asdf", 0 },
                    { 10, "Placeholder Description", "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", "Giant Sunflower", 1.00m, "abci876k", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
