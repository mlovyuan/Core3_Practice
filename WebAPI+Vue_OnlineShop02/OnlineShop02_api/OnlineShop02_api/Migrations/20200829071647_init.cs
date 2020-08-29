using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop02_api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ps");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "ps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    OrgPrice = table.Column<decimal>(nullable: false),
                    Decoration = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    ClickTimes = table.Column<int>(nullable: false),
                    SaleTimes = table.Column<int>(nullable: false),
                    IdDel = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products",
                schema: "ps");
        }
    }
}
