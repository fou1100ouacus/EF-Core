using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationEFCore10.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CourseName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Courses__3214EC0755FA43A5", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    OfficeName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    OfficeLocation = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Offices__3214EC07C614CF32", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    SUN = table.Column<bool>(type: "bit", nullable: false),
                    MON = table.Column<bool>(type: "bit", nullable: false),
                    TUE = table.Column<bool>(type: "bit", nullable: false),
                    WED = table.Column<bool>(type: "bit", nullable: false),
                    THU = table.Column<bool>(type: "bit", nullable: false),
                    FRI = table.Column<bool>(type: "bit", nullable: false),
                    SAT = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Schedule__3214EC07B6CD2009", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Students__3214EC07F98B1C75", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Instruct__3214EC07C60CC125", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Instructo__Offic__3B75D760",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SectionName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    InstructorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Sections__3214EC07C1F9A3ED", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Sections__Course__3E52440B",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Sections__Instru__3F466844",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Enrollme__0ACBDB1E387E83EF", x => new { x.StudentId, x.SectionId });
                    table.ForeignKey(
                        name: "FK__Enrollmen__Secti__4AB81AF0",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Enrollmen__Stude__49C3F6B7",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SectionSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SectionS__3214EC07BEF980A6", x => x.Id);
                    table.ForeignKey(
                        name: "FK__SectionSc__Sched__44FF419A",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__SectionSc__Secti__440B1D61",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "idx_enrollments_section_id",
                table: "Enrollments",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_OfficeId",
                table: "Instructors",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "idx_sections_course_id",
                table: "Sections",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "idx_sections_instructor_id",
                table: "Sections",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "idx_section_schedules_schedule_id",
                table: "SectionSchedules",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionSchedules_SectionId",
                table: "SectionSchedules",
                column: "SectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "SectionSchedules");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Offices");
        }
    }
}
