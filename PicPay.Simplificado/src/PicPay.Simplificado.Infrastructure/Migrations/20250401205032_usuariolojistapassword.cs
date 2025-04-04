using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PicPay.Simplificado.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class usuariolojistapassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "UsuarioLojista",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "UsuarioLojista",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "UsuarioLojista");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "UsuarioLojista");
        }
    }
}
