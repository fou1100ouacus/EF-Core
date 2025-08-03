using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF010.InitialMigration.Migrations
{
    /// <inheritdoc />
    public partial class SplitInstructorName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Instructors",
                newName: "LName");

            migrationBuilder.AddColumn<string>(
                name: "FName",
                table: "Instructors",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FName",
                table: "Instructors");

            migrationBuilder.RenameColumn(
                name: "LName",
                table: "Instructors",
                newName: "Name");
        }
    }
}
