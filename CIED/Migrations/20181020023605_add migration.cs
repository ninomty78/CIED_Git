using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CIED.Migrations
{
    public partial class addmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaID",
                table: "Apunte",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false),
                    Estatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apunte_CategoriaID",
                table: "Apunte",
                column: "CategoriaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Apunte_Categoria_CategoriaID",
                table: "Apunte",
                column: "CategoriaID",
                principalTable: "Categoria",
                principalColumn: "CategoriaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apunte_Categoria_CategoriaID",
                table: "Apunte");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropIndex(
                name: "IX_Apunte_CategoriaID",
                table: "Apunte");

            migrationBuilder.DropColumn(
                name: "CategoriaID",
                table: "Apunte");
        }
    }
}
