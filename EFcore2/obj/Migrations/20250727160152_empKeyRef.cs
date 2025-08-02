using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCORE2.Migrations
{
    /// <inheritdoc />
    public partial class empKeyRef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_Employees_empid",
                table: "tasks");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.RenameColumn(
                name: "empid",
                table: "tasks",
                newName: "empID");

            migrationBuilder.RenameIndex(
                name: "IX_tasks_empid",
                table: "tasks",
                newName: "IX_tasks_empID");

            migrationBuilder.AddColumn<int>(
                name: "employeeid",
                table: "tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tasks_employeeid",
                table: "tasks",
                column: "employeeid");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_Employees_empID",
                table: "tasks",
                column: "empID",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_Employees_employeeid",
                table: "tasks",
                column: "employeeid",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_Employees_empID",
                table: "tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_tasks_Employees_employeeid",
                table: "tasks");

            migrationBuilder.DropIndex(
                name: "IX_tasks_employeeid",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "employeeid",
                table: "tasks");

            migrationBuilder.RenameColumn(
                name: "empID",
                table: "tasks",
                newName: "empid");

            migrationBuilder.RenameIndex(
                name: "IX_tasks_empID",
                table: "tasks",
                newName: "IX_tasks_empid");

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    blogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.id);
                    table.ForeignKey(
                        name: "FK_posts_Blog_blogId",
                        column: x => x.blogId,
                        principalTable: "Blog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_posts_blogId",
                table: "posts",
                column: "blogId");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_Employees_empid",
                table: "tasks",
                column: "empid",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
