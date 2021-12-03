using Microsoft.EntityFrameworkCore.Migrations;

namespace ChorseBackend.Migrations
{
    public partial class newProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "assignee",
                table: "Chores",
                newName: "kanban_id");

            migrationBuilder.AddColumn<int>(
                name: "assigneeid",
                table: "Chores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chores_assigneeid",
                table: "Chores",
                column: "assigneeid");

            migrationBuilder.AddForeignKey(
                name: "FK_Chores_Client_assigneeid",
                table: "Chores",
                column: "assigneeid",
                principalTable: "Client",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chores_Client_assigneeid",
                table: "Chores");

            migrationBuilder.DropIndex(
                name: "IX_Chores_assigneeid",
                table: "Chores");

            migrationBuilder.DropColumn(
                name: "assigneeid",
                table: "Chores");

            migrationBuilder.RenameColumn(
                name: "kanban_id",
                table: "Chores",
                newName: "assignee");
        }
    }
}
