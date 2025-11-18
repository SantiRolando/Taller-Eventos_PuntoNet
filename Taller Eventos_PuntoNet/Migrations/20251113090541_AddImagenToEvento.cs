using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallerEventos_PuntoNet.Migrations
{
    /// <inheritdoc />
    public partial class AddImagenToEvento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Imagen",
                table: "Eventos",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Eventos");
        }
    }
}
