
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Entities.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Direccion = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Operarios",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Partidas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CantSinClasificar = table.Column<int>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    FechaIngreso = table.Column<DateTime>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true),
                    PesoPromedio = table.Column<decimal>(nullable: false),
                    Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubPartidas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Calidad = table.Column<int>(nullable: false),
                    CantCueros = table.Column<int>(nullable: false),
                    Eficiencia = table.Column<decimal>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    PartidaID = table.Column<int>(nullable: false),
                    PedidoID = table.Column<int>(nullable: true),
                    Stock = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubPartidas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SubPartidas_Partidas_PartidaID",
                        column: x => x.PartidaID,
                        principalTable: "Partidas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubPartidas_Pedidos_PedidoID",
                        column: x => x.PedidoID,
                        principalTable: "Pedidos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProcesosHumedos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fin = table.Column<TimeSpan>(nullable: false),
                    Inicio = table.Column<TimeSpan>(nullable: false),
                    Proceso = table.Column<int>(nullable: false),
                    SubPartidaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcesosHumedos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProcesosHumedos_SubPartidas_SubPartidaID",
                        column: x => x.SubPartidaID,
                        principalTable: "SubPartidas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteID",
                table: "Pedidos",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_ProcesosHumedos_SubPartidaID",
                table: "ProcesosHumedos",
                column: "SubPartidaID");

            migrationBuilder.CreateIndex(
                name: "IX_SubPartidas_PartidaID",
                table: "SubPartidas",
                column: "PartidaID");

            migrationBuilder.CreateIndex(
                name: "IX_SubPartidas_PedidoID",
                table: "SubPartidas",
                column: "PedidoID",
                unique: true,
                filter: "[PedidoID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operarios");

            migrationBuilder.DropTable(
                name: "ProcesosHumedos");

            migrationBuilder.DropTable(
                name: "SubPartidas");

            migrationBuilder.DropTable(
                name: "Partidas");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
