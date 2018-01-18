using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Entities.Migrations
{
    public partial class RecetaHumedaPosta1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Insumos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<int>(nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insumos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RecetaHumedas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcesoHumedoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecetaHumedas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RecetaHumedas_ProcesosHumedos_ProcesoHumedoID",
                        column: x => x.ProcesoHumedoID,
                        principalTable: "ProcesosHumedos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemsReceta",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cantidad = table.Column<int>(nullable: false),
                    InsumoID = table.Column<int>(nullable: false),
                    RecetaHumedaID = table.Column<int>(nullable: true),
                    RecetaID = table.Column<int>(nullable: false),
                    Tiempo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsReceta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ItemsReceta_Insumos_InsumoID",
                        column: x => x.InsumoID,
                        principalTable: "Insumos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemsReceta_RecetaHumedas_RecetaHumedaID",
                        column: x => x.RecetaHumedaID,
                        principalTable: "RecetaHumedas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemsReceta_InsumoID",
                table: "ItemsReceta",
                column: "InsumoID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsReceta_RecetaHumedaID",
                table: "ItemsReceta",
                column: "RecetaHumedaID");

            migrationBuilder.CreateIndex(
                name: "IX_RecetaHumedas_ProcesoHumedoID",
                table: "RecetaHumedas",
                column: "ProcesoHumedoID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemsReceta");

            migrationBuilder.DropTable(
                name: "Insumos");

            migrationBuilder.DropTable(
                name: "RecetaHumedas");
        }
    }
}
