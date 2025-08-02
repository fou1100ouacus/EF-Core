using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCORE2.Migrations
{
    /// <inheritdoc />
    public partial class editmige : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tasks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empID = table.Column<int>(type: "int", nullable: false),
                    employeeid = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "this is comment")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks", x => x.id);
                    table.ForeignKey(
                        name: "FK_tasks_Employees_empID",
                        column: x => x.empID,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tasks_Employees_employeeid",
                        column: x => x.employeeid,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tasks_empID",
                table: "tasks",
                column: "empID");

            migrationBuilder.CreateIndex(
                name: "IX_tasks_employeeid",
                table: "tasks",
                column: "employeeid");
        }
    }
}
