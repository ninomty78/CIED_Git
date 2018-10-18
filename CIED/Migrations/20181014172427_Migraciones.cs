using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CIED.Migrations
{
    public partial class Migraciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "Apunte",
                columns: table => new
                {
                    ApunteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false),
                    Importe = table.Column<double>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Estatus = table.Column<bool>(nullable: false),
                    TipoApunteID = table.Column<int>(nullable: false),
                    EmpresaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apunte", x => x.ApunteID);
                    table.ForeignKey(
                        name: "FK_Apunte_Empresa_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresa",
                        principalColumn: "EmpresaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apunte_TipoApunte_TipoApunteID",
                        column: x => x.TipoApunteID,
                        principalTable: "TipoApunte",
                        principalColumn: "TipoApunteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apunte_EmpresaID",
                table: "Apunte",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_Apunte_TipoApunteID",
                table: "Apunte",
                column: "TipoApunteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apunte");

        }
    }
}
