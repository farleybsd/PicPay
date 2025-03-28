using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PicPay.Simplificado.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transferencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioOrigemId = table.Column<int>(type: "int", nullable: false),
                    NomeOrigem = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    NomeDestino = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    UsuarioDestinoId = table.Column<int>(type: "int", nullable: false),
                    TipoPagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaldoTransferencia = table.Column<double>(type: "float", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SucessoNaTransferencia = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferencia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioComun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioNome_NomeCompleto = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Saldo = table.Column<double>(type: "float", nullable: false),
                    UsuarioCategoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioComun", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioLojista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioNome_NomeCompleto = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Saldo = table.Column<double>(type: "float", nullable: false),
                    UsuarioCategoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioLojista", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioComun_CPF",
                table: "UsuarioComun",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioComun_Email",
                table: "UsuarioComun",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioLojista_CNPJ",
                table: "UsuarioLojista",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioLojista_Email",
                table: "UsuarioLojista",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transferencia");

            migrationBuilder.DropTable(
                name: "UsuarioComun");

            migrationBuilder.DropTable(
                name: "UsuarioLojista");
        }
    }
}
