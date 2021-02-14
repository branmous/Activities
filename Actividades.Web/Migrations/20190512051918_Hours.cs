using Microsoft.EntityFrameworkCore.Migrations;

namespace Actividades.Web.Migrations
{
    public partial class Hours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeActivity_Actividades_ActividadId",
                table: "TimeActivity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeActivity",
                table: "TimeActivity");

            migrationBuilder.RenameTable(
                name: "TimeActivity",
                newName: "TimeActivities");

            migrationBuilder.RenameIndex(
                name: "IX_TimeActivity_ActividadId",
                table: "TimeActivities",
                newName: "IX_TimeActivities_ActividadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeActivities",
                table: "TimeActivities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeActivities_Actividades_ActividadId",
                table: "TimeActivities",
                column: "ActividadId",
                principalTable: "Actividades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeActivities_Actividades_ActividadId",
                table: "TimeActivities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeActivities",
                table: "TimeActivities");

            migrationBuilder.RenameTable(
                name: "TimeActivities",
                newName: "TimeActivity");

            migrationBuilder.RenameIndex(
                name: "IX_TimeActivities_ActividadId",
                table: "TimeActivity",
                newName: "IX_TimeActivity_ActividadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeActivity",
                table: "TimeActivity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeActivity_Actividades_ActividadId",
                table: "TimeActivity",
                column: "ActividadId",
                principalTable: "Actividades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
