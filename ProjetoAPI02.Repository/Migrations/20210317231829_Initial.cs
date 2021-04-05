using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoAPI02.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    IDCLIENTE = table.Column<Guid>(nullable: false),
                    NOME = table.Column<string>(maxLength: 150, nullable: false),
                    EMAIL = table.Column<string>(maxLength: 100, nullable: false),
                    CPF = table.Column<string>(maxLength: 14, nullable: false),
                    Senha = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.IDCLIENTE);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTO",
                columns: table => new
                {
                    IDPRODUTO = table.Column<Guid>(nullable: false),
                    NOME = table.Column<string>(maxLength: 150, nullable: false),
                    PRECO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DESCRICAO = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.IDPRODUTO);
                });

            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    IDENDERECO = table.Column<Guid>(nullable: false),
                    LOGRADOURO = table.Column<string>(maxLength: 150, nullable: false),
                    NUMERO = table.Column<string>(maxLength: 10, nullable: false),
                    COMPLEMENTO = table.Column<string>(maxLength: 150, nullable: false),
                    BAIRRO = table.Column<string>(maxLength: 100, nullable: false),
                    CIDADE = table.Column<string>(maxLength: 100, nullable: false),
                    ESTADO = table.Column<string>(maxLength: 25, nullable: false),
                    CEP = table.Column<string>(maxLength: 10, nullable: false),
                    IdCliente = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECO", x => x.IDENDERECO);
                    table.ForeignKey(
                        name: "FK_ENDERECO_CLIENTE_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "CLIENTE",
                        principalColumn: "IDCLIENTE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PEDIDO",
                columns: table => new
                {
                    IDPEDIDO = table.Column<Guid>(nullable: false),
                    DATAPEDIDO = table.Column<DateTime>(type: "date", nullable: false),
                    VALORTOTAL = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IDCLIENTE = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDO", x => x.IDPEDIDO);
                    table.ForeignKey(
                        name: "FK_PEDIDO_CLIENTE_IDCLIENTE",
                        column: x => x.IDCLIENTE,
                        principalTable: "CLIENTE",
                        principalColumn: "IDCLIENTE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ITEMPEDIDO",
                columns: table => new
                {
                    IDITEMPEDIDO = table.Column<Guid>(nullable: false),
                    IDPEDIDO = table.Column<Guid>(nullable: false),
                    IDPRODUTO = table.Column<Guid>(nullable: false),
                    QUANTIDADE = table.Column<int>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITEMPEDIDO", x => x.IDITEMPEDIDO);
                    table.ForeignKey(
                        name: "FK_ITEMPEDIDO_PEDIDO_IDPEDIDO",
                        column: x => x.IDPEDIDO,
                        principalTable: "PEDIDO",
                        principalColumn: "IDPEDIDO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ITEMPEDIDO_PRODUTO_IDPRODUTO",
                        column: x => x.IDPRODUTO,
                        principalTable: "PRODUTO",
                        principalColumn: "IDPRODUTO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECO_IdCliente",
                table: "ENDERECO",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_ITEMPEDIDO_IDPEDIDO",
                table: "ITEMPEDIDO",
                column: "IDPEDIDO");

            migrationBuilder.CreateIndex(
                name: "IX_ITEMPEDIDO_IDPRODUTO",
                table: "ITEMPEDIDO",
                column: "IDPRODUTO");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDO_IDCLIENTE",
                table: "PEDIDO",
                column: "IDCLIENTE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ENDERECO");

            migrationBuilder.DropTable(
                name: "ITEMPEDIDO");

            migrationBuilder.DropTable(
                name: "PEDIDO");

            migrationBuilder.DropTable(
                name: "PRODUTO");

            migrationBuilder.DropTable(
                name: "CLIENTE");
        }
    }
}
