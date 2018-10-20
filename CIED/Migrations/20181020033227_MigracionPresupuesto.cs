using Microsoft.EntityFrameworkCore.Migrations;

namespace CIED.Migrations
{
    public partial class MigracionPresupuesto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Importe",
                table: "Apunte",
                nullable: false,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Importe",
                table: "Apunte",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
