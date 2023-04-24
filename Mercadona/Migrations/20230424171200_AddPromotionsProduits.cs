using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mercadona.Migrations
{
    public partial class AddPromotionsProduits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProduitsModelId",
                table: "Promotions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_ProduitsModelId",
                table: "Promotions",
                column: "ProduitsModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Produits_ProduitsModelId",
                table: "Promotions",
                column: "ProduitsModelId",
                principalTable: "Produits",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Produits_ProduitsModelId",
                table: "Promotions");

            migrationBuilder.DropIndex(
                name: "IX_Promotions_ProduitsModelId",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "ProduitsModelId",
                table: "Promotions");
        }
    }
}
