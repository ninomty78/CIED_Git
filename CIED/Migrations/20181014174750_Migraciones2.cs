using Microsoft.EntityFrameworkCore.Migrations;

namespace CIED.Migrations
{
    public partial class Migraciones2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SlotID",
                table: "Apunte",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Apunte_SlotID",
                table: "Apunte",
                column: "SlotID");

            migrationBuilder.AddForeignKey(
                name: "FK_Apunte_Slot_SlotID",
                table: "Apunte",
                column: "SlotID",
                principalTable: "Slot",
                principalColumn: "SlotID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apunte_Slot_SlotID",
                table: "Apunte");

            migrationBuilder.DropIndex(
                name: "IX_Apunte_SlotID",
                table: "Apunte");

            migrationBuilder.DropColumn(
                name: "SlotID",
                table: "Apunte");
        }
    }
}
