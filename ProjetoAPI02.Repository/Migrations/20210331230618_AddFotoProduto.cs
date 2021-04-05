using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoAPI02.Repository.Migrations
{
    public partial class AddFotoProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FOTO",
                table: "PRODUTO",
                maxLength: 150,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FOTO",
                table: "PRODUTO");
        }
    }
}
