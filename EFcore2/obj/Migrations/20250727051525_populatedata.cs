using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCORE2.Migrations
{
    /// <inheritdoc />
    public partial class populatedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Employees VALUES ('Employees 1','sfsfas')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Employees where  name= 'Employees 1' ");


        }
    }
}
