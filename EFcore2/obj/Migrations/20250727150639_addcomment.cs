using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCORE2.Migrations
{
    /// <inheritdoc />
    public partial class addcomment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "tasks",
                type: "nvarchar(max)",
                nullable: false,
                comment: "this is comment",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "tasks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "this is comment");
        }
    }
}
