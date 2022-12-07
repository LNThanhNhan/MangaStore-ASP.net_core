using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangaStore.Migrations
{
    public partial class create_products_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    slug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    author_slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    list_price = table.Column<long>(type: "bigint", nullable: false),
                    price = table.Column<long>(type: "bigint", nullable: false),
                    discount_rate = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    publish_year = table.Column<int>(type: "int", nullable: false),
                    size = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    collection = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    collection_slug = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_name",
                table: "Products",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_slug",
                table: "Products",
                column: "slug",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
