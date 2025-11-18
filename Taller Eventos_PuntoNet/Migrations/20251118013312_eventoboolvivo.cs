using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallerEventos_PuntoNet.Migrations
{
    /// <inheritdoc />
    public partial class eventoboolvivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EnVivo",
                table: "Eventos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnVivo",
                table: "Eventos");
        }
    }
}
