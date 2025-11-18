using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallerEventos_PuntoNet.Migrations
{
    /// <inheritdoc />
    public partial class eventoboolvivo2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Eventos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Ubicacion",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Ubicacion",
                table: "Eventos");
        }
    }
}
