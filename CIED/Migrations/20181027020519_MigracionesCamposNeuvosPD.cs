using Microsoft.EntityFrameworkCore.Migrations;

namespace CIED.Migrations
{
    public partial class MigracionesCamposNeuvosPD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CantidadRestante",
                table: "PresupuestoDetalle",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentajeRestante",
                table: "PresupuestoDetalle",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Real",
                table: "PresupuestoDetalle",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadRestante",
                table: "PresupuestoDetalle");

            migrationBuilder.DropColumn(
                name: "PorcentajeRestante",
                table: "PresupuestoDetalle");

            migrationBuilder.DropColumn(
                name: "Real",
                table: "PresupuestoDetalle");
        }
    }
}
