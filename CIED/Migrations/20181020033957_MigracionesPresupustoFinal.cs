using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CIED.Migrations
{
    public partial class MigracionesPresupustoFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Presupuesto",
                columns: table => new
                {
                    PresupuestoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false),
                    Anio = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presupuesto", x => x.PresupuestoID);
                });

            migrationBuilder.CreateTable(
                name: "PresupuestoDetalle",
                columns: table => new
                {
                    PresupuestoDetalleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PresupuestoID = table.Column<int>(nullable: false),
                    CategoriaID = table.Column<int>(nullable: false),
                    Partida = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresupuestoDetalle", x => x.PresupuestoDetalleID);
                    table.ForeignKey(
                        name: "FK_PresupuestoDetalle_Categoria_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PresupuestoDetalle_Presupuesto_PresupuestoID",
                        column: x => x.PresupuestoID,
                        principalTable: "Presupuesto",
                        principalColumn: "PresupuestoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PresupuestoDetalle_CategoriaID",
                table: "PresupuestoDetalle",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_PresupuestoDetalle_PresupuestoID",
                table: "PresupuestoDetalle",
                column: "PresupuestoID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PresupuestoDetalle");

            migrationBuilder.DropTable(
                name: "Presupuesto");
        }
    }
}
