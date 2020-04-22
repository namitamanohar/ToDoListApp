using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDo.Data.Migrations
{
    public partial class smallchages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItem_AspNetUsers_ApplicationUserId1",
                table: "ToDoItem");

            migrationBuilder.DropIndex(
                name: "IX_ToDoItem_ApplicationUserId1",
                table: "ToDoItem");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ToDoItem");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ToDoItem",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItem_ApplicationUserId",
                table: "ToDoItem",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItem_AspNetUsers_ApplicationUserId",
                table: "ToDoItem",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItem_AspNetUsers_ApplicationUserId",
                table: "ToDoItem");

            migrationBuilder.DropIndex(
                name: "IX_ToDoItem_ApplicationUserId",
                table: "ToDoItem");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "ToDoItem",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ToDoItem",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItem_ApplicationUserId1",
                table: "ToDoItem",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItem_AspNetUsers_ApplicationUserId1",
                table: "ToDoItem",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
