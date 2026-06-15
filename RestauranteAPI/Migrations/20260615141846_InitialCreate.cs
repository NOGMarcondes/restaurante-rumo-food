using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestauranteAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemPedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PedidoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProdutoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    numMesa = table.Column<int>(type: "INTEGER", nullable: false),
                    NomeCliente = table.Column<string>(type: "TEXT", nullable: false),
                    StatusPedido = table.Column<string>(type: "TEXT", nullable: false),
                    DataPedido = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    SetorPedido = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeProduto = table.Column<string>(type: "TEXT", nullable: false),
                    TipoProduto = table.Column<string>(type: "TEXT", nullable: false),
                    ValorProduto = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    senha = table.Column<string>(type: "TEXT", nullable: false),
                    perfil = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "NomeProduto", "TipoProduto", "ValorProduto" },
                values: new object[,]
                {
                    { 1, "Frango Grelhado", "Prato", 28.0 },
                    { 2, "Filé ao Molho Madeira", "Prato", 45.0 },
                    { 3, "Suco de Laranja", "Bebida", 8.0 },
                    { 4, "Refrigerante Cola", "Bebida", 6.0 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "email", "name", "perfil", "senha" },
                values: new object[,]
                {
                    { 1, "funcionario@rest.com", "Funcionario", "Funcionario", "123456" },
                    { 2, "cozinha@rest.com", "Cozinha", "Cozinha", "123456" },
                    { 3, "copa@rest.com", "Copa", "Copa", "123456" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemPedidos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
