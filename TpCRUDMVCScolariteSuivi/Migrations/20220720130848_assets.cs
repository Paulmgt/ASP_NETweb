using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TpCRUDMVCScolariteSuivi.Migrations
{
    public partial class assets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcours_Modules_ModuleId",
                table: "Parcours");

            migrationBuilder.AlterColumn<int>(
                name: "ModuleId",
                table: "Parcours",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcours_Modules_ModuleId",
                table: "Parcours",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcours_Modules_ModuleId",
                table: "Parcours");

            migrationBuilder.AlterColumn<int>(
                name: "ModuleId",
                table: "Parcours",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcours_Modules_ModuleId",
                table: "Parcours",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id");
        }
    }
}
