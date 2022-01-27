using Microsoft.EntityFrameworkCore.Migrations;

namespace CriptoDB.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contrato_Moneda_MonedaId1",
                table: "Contrato");

            migrationBuilder.DropIndex(
                name: "IX_Contrato_CarteraId_MonedaId",
                table: "Contrato");

            migrationBuilder.DropIndex(
                name: "IX_Contrato_MonedaId1",
                table: "Contrato");

            migrationBuilder.DropColumn(
                name: "MonedaId1",
                table: "Contrato");

            migrationBuilder.AlterColumn<string>(
                name: "MonedaId",
                table: "Contrato",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_CarteraId_MonedaId",
                table: "Contrato",
                columns: new[] { "CarteraId", "MonedaId" },
                unique: true,
                filter: "[MonedaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_MonedaId",
                table: "Contrato",
                column: "MonedaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contrato_Moneda_MonedaId",
                table: "Contrato",
                column: "MonedaId",
                principalTable: "Moneda",
                principalColumn: "MonedaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contrato_Moneda_MonedaId",
                table: "Contrato");

            migrationBuilder.DropIndex(
                name: "IX_Contrato_CarteraId_MonedaId",
                table: "Contrato");

            migrationBuilder.DropIndex(
                name: "IX_Contrato_MonedaId",
                table: "Contrato");

            migrationBuilder.AlterColumn<int>(
                name: "MonedaId",
                table: "Contrato",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonedaId1",
                table: "Contrato",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_CarteraId_MonedaId",
                table: "Contrato",
                columns: new[] { "CarteraId", "MonedaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_MonedaId1",
                table: "Contrato",
                column: "MonedaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contrato_Moneda_MonedaId1",
                table: "Contrato",
                column: "MonedaId1",
                principalTable: "Moneda",
                principalColumn: "MonedaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
