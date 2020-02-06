using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiWithDI.Migrations
{
    public partial class WebApiWithDISqlServerTodoContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoItemSqlServer",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItemSqlServer", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TodoItemSqlServer",
                columns: new[] { "Id", "IsComplete", "Name" },
                values: new object[] { 1L, true, "Pepe From Sql Server" });

            migrationBuilder.InsertData(
                table: "TodoItemSqlServer",
                columns: new[] { "Id", "IsComplete", "Name" },
                values: new object[] { 2L, true, "Pepe From Sql Server" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItemSqlServer");
        }
    }
}
