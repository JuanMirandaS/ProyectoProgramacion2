using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoProgramacion2.Migrations
{
    /// <inheritdoc />
    public partial class IniciarBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdProyecto",
                table: "Tarea",
                newName: "UsuarioID");

            migrationBuilder.RenameColumn(
                name: "IdEmpleado",
                table: "Tarea",
                newName: "ProyectoID");

            migrationBuilder.AddColumn<string>(
                name: "SetHerramientas",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_ProyectoID",
                table: "Tarea",
                column: "ProyectoID");

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_UsuarioID",
                table: "Tarea",
                column: "UsuarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_Proyecto_ProyectoID",
                table: "Tarea",
                column: "ProyectoID",
                principalTable: "Proyecto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_Usuario_UsuarioID",
                table: "Tarea",
                column: "UsuarioID",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_Proyecto_ProyectoID",
                table: "Tarea");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_Usuario_UsuarioID",
                table: "Tarea");

            migrationBuilder.DropIndex(
                name: "IX_Tarea_ProyectoID",
                table: "Tarea");

            migrationBuilder.DropIndex(
                name: "IX_Tarea_UsuarioID",
                table: "Tarea");

            migrationBuilder.DropColumn(
                name: "SetHerramientas",
                table: "Tarea");

            migrationBuilder.RenameColumn(
                name: "UsuarioID",
                table: "Tarea",
                newName: "IdProyecto");

            migrationBuilder.RenameColumn(
                name: "ProyectoID",
                table: "Tarea",
                newName: "IdEmpleado");
        }
    }
}
