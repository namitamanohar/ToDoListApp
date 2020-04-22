using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDo.Data.Migrations
{
    public partial class SeedingStatusTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ToDoStatus",
                columns: new[] { "Id", "Status" },
                values: new object[] { 1, "Todo" });

            migrationBuilder.InsertData(
                table: "ToDoStatus",
                columns: new[] { "Id", "Status" },
                values: new object[] { 2, "In Progress" });

            migrationBuilder.InsertData(
                table: "ToDoStatus",
                columns: new[] { "Id", "Status" },
                values: new object[] { 3, "Done" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ToDoStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ToDoStatus",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
