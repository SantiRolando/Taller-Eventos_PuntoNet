using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallerEventos_PuntoNet.Migrations
{
    /// <inheritdoc />
    public partial class AddDiscriminator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Añade la columna TipoUsuario con valor por defecto para no romper filas existentes
            migrationBuilder.AddColumn<string>(
                name: "TipoUsuario",
                table: "Usuarios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "Participante");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoUsuario",
                table: "Usuarios");
        }
    }
}
