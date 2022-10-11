using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fridge.ProductsService.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultQuantity = table.Column<int>(type: "int", nullable: false),
                    ImageSource = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "ImageSource", "Name" },
                values: new object[,]
                {
                    { new Guid("5edcdb18-b675-4ccb-ba7f-d68226a939f5"), 5, "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7b/Assorted_bread.jpg/274px-Assorted_bread.jpg", "Bread" },
                    { new Guid("d4473a8a-c8bc-4aa1-9488-2daee630476f"), 10, "https://id-test-11.slatic.net/p/70f40d8f77f844671af4a5a11755e7ae.jpg", "Apple" },
                    { new Guid("fbfc3635-0579-4eb4-917b-1fcdd789afea"), 15, "https://cdn.yamatoscale.com/wp-content/uploads/2016/04/K%C3%A4se-Scheiben_01_00_OH-1.jpg", "Cheese" },
                    { new Guid("71fe1cf5-db7b-4be2-9f6f-b3dcd45f3023"), 11, "https://4.imimg.com/data4/JX/UQ/ANDROID-47104262/product-500x500.jpeg", "Mashroom" },
                    { new Guid("dd36a942-f381-49cf-b66b-b34cd8ebbf7a"), 3, "https://preview.free3d.com/img/2017/05/2279485108920518249/e92jihnh-900.jpg", "Fish" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
