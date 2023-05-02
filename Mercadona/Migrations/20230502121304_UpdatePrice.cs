using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mercadona.Migrations
{
    public partial class UpdatePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "prixPromo",
                table: "PromotionsProduits",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "prixPromo",
                table: "PromotionsProduits",
                type: "integer",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
