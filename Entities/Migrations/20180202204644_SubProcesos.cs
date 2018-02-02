using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Entities.Migrations
{
    public partial class SubProcesos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tiempo",
                table: "ItemsReceta",
                newName: "Porcentaje");

            migrationBuilder.RenameColumn(
                name: "RecetaID",
                table: "ItemsReceta",
                newName: "SubProcesoID");

            migrationBuilder.AddColumn<decimal>(
                name: "KgG",
                table: "ItemsReceta",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "SubProcesos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Be = table.Column<decimal>(nullable: false),
                    Fin = table.Column<TimeSpan>(nullable: false),
                    Inicio = table.Column<TimeSpan>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Observaciones = table.Column<string>(nullable: true),
                    Ph = table.Column<decimal>(nullable: false),
                    ProcesoHumedoID = table.Column<int>(nullable: false),
                    RecetaHumedaID = table.Column<int>(nullable: true),
                    RecetaID = table.Column<int>(nullable: false),
                    Temp = table.Column<decimal>(nullable: false),
                    Tiempo = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubProcesos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SubProcesos_ProcesosHumedos_ProcesoHumedoID",
                        column: x => x.ProcesoHumedoID,
                        principalTable: "ProcesosHumedos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubProcesos_RecetaHumedas_RecetaHumedaID",
                        column: x => x.RecetaHumedaID,
                        principalTable: "RecetaHumedas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemsReceta_SubProcesoID",
                table: "ItemsReceta",
                column: "SubProcesoID");

            migrationBuilder.CreateIndex(
                name: "IX_SubProcesos_ProcesoHumedoID",
                table: "SubProcesos",
                column: "ProcesoHumedoID");

            migrationBuilder.CreateIndex(
                name: "IX_SubProcesos_RecetaHumedaID",
                table: "SubProcesos",
                column: "RecetaHumedaID");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsReceta_SubProcesos_SubProcesoID",
                table: "ItemsReceta",
                column: "SubProcesoID",
                principalTable: "SubProcesos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsReceta_SubProcesos_SubProcesoID",
                table: "ItemsReceta");

            migrationBuilder.DropTable(
                name: "SubProcesos");

            migrationBuilder.DropIndex(
                name: "IX_ItemsReceta_SubProcesoID",
                table: "ItemsReceta");

            migrationBuilder.DropColumn(
                name: "KgG",
                table: "ItemsReceta");

            migrationBuilder.RenameColumn(
                name: "SubProcesoID",
                table: "ItemsReceta",
                newName: "RecetaID");

            migrationBuilder.RenameColumn(
                name: "Porcentaje",
                table: "ItemsReceta",
                newName: "Tiempo");
        }
    }
}
