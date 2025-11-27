using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coursera_Exercise.Migrations
{
    /// <inheritdoc />
    public partial class InitModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time_created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    PIN = table.Column<string>(type: "nchar(10)", nullable: false),
                    First_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time_created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.PIN);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instructor_id = table.Column<int>(type: "int", nullable: false),
                    Total_time = table.Column<short>(type: "smallint", nullable: false),
                    Credit = table.Column<short>(type: "smallint", nullable: false),
                    Time_created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Instructors_Instructor_id",
                        column: x => x.Instructor_id,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsCourse",
                columns: table => new
                {
                    Student_pin = table.Column<string>(type: "nchar(10)", nullable: false),
                    Course_id = table.Column<int>(type: "int", nullable: false),
                    Completion_Date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsCourse", x => new { x.Student_pin, x.Course_id });
                    table.ForeignKey(
                        name: "FK_StudentsCourse_Courses_Course_id",
                        column: x => x.Course_id,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsCourse_Students_Student_pin",
                        column: x => x.Student_pin,
                        principalTable: "Students",
                        principalColumn: "PIN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Instructor_id",
                table: "Courses",
                column: "Instructor_id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourse_Course_id",
                table: "StudentsCourse",
                column: "Course_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsCourse");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Instructors");
        }
    }
}
