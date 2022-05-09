using Microsoft.EntityFrameworkCore.Migrations;

namespace MilanEducationEF.Data.Migrations
{
    public partial class ChangingEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskEntity_ProjectEntity_ProjectId",
                table: "TaskEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskEntity",
                table: "TaskEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectEntity",
                table: "ProjectEntity");

            migrationBuilder.RenameTable(
                name: "TaskEntity",
                newName: "Tasks");

            migrationBuilder.RenameTable(
                name: "ProjectEntity",
                newName: "Projects");

            migrationBuilder.RenameIndex(
                name: "IX_TaskEntity_ProjectId",
                table: "Tasks",
                newName: "IX_Tasks_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "TaskEntity");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "ProjectEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ProjectId",
                table: "TaskEntity",
                newName: "IX_TaskEntity_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskEntity",
                table: "TaskEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectEntity",
                table: "ProjectEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskEntity_ProjectEntity_ProjectId",
                table: "TaskEntity",
                column: "ProjectId",
                principalTable: "ProjectEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
