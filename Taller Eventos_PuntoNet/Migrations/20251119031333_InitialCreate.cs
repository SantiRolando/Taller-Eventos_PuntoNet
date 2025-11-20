using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallerEventos_PuntoNet.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Km = table.Column<int>(type: "int", nullable: false),
                    Cantidad_Inscritos = table.Column<int>(type: "int", nullable: false),
                    Cantidad_Kits = table.Column<int>(type: "int", nullable: false),
                    EnVivo = table.Column<bool>(type: "bit", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Imagen = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Ci = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoUsuario = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Ci);
                });

            migrationBuilder.CreateTable(
                name: "Sensores",
                columns: table => new
                {
                    Id_Sensor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Distancia = table.Column<int>(type: "int", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensores", x => x.Id_Sensor);
                    table.ForeignKey(
                        name: "FK_Sensores_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ci_Usuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id_Evento = table.Column<int>(type: "int", nullable: false),
                    Id_Chip = table.Column<int>(type: "int", nullable: false),
                    Dorsal_Atleta = table.Column<int>(type: "int", nullable: false),
                    ParticipanteCi = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Eventos_Id_Evento",
                        column: x => x.Id_Evento,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Usuarios_Ci_Usuario",
                        column: x => x.Ci_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Ci",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Usuarios_ParticipanteCi",
                        column: x => x.ParticipanteCi,
                        principalTable: "Usuarios",
                        principalColumn: "Ci");
                });

            migrationBuilder.CreateTable(
                name: "Leaderboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dorsal_Atleta = table.Column<int>(type: "int", nullable: false),
                    Id_Sensor = table.Column<int>(type: "int", nullable: false),
                    Tiempo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaderboards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leaderboards_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Leaderboards_Sensores_Id_Sensor",
                        column: x => x.Id_Sensor,
                        principalTable: "Sensores",
                        principalColumn: "Id_Sensor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dorsal_Atleta = table.Column<int>(type: "int", nullable: false),
                    Id_Sensor = table.Column<int>(type: "int", nullable: false),
                    Tiempo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Marcas_Sensores_Id_Sensor",
                        column: x => x.Id_Sensor,
                        principalTable: "Sensores",
                        principalColumn: "Id_Sensor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_Ci_Usuario",
                table: "Inscripciones",
                column: "Ci_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_Id_Evento",
                table: "Inscripciones",
                column: "Id_Evento");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_ParticipanteCi",
                table: "Inscripciones",
                column: "ParticipanteCi");

            migrationBuilder.CreateIndex(
                name: "IX_Leaderboards_EventoId",
                table: "Leaderboards",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaderboards_Id_Sensor",
                table: "Leaderboards",
                column: "Id_Sensor");

            migrationBuilder.CreateIndex(
                name: "IX_Marcas_Id_Sensor",
                table: "Marcas",
                column: "Id_Sensor");

            migrationBuilder.CreateIndex(
                name: "IX_Sensores_EventoId",
                table: "Sensores",
                column: "EventoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "Leaderboards");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Sensores");

            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
