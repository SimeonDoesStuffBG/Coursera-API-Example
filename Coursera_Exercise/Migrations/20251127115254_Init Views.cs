using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coursera_Exercise.Migrations
{
    /// <inheritdoc />
    public partial class InitViews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string createSCrCommand = @"CREATE VIEW StudentCredits AS
                                            SELECT Students.PIN as Student_PIN, CONCAT_WS(' ', Students.first_name, Students.Last_name) as student_name, SUM(Courses.Credit) as total_credit
                                                FROM Students
                                                LEFT JOIN StudentsCourse
                                                ON Students.PIN = StudentsCourse.Student_pin
                                                LEFT JOIN Courses
                                                ON StudentsCourse.Course_id = Courses.Id
                                                WHERE StudentsCourse.Completion_Date IS NOT NULL
                                                GROUP BY Students.PIN, Students.First_name, Students.Last_name;";
            migrationBuilder.Sql(createSCrCommand);

            string createCDCommand = @"CREATE VIEW CourseDetails AS
                                            SELECT Courses.Id as Course_Id, Courses.Name AS Course_name, Courses.Total_time, Courses.Credit, CONCAT_WS(' ', Instructors.First_Name, Instructors.Last_Name) as Instructor_Name
                                                FROM Courses
                                                LEFT JOIN Instructors
                                                ON Instructors.Id = Courses.Instructor_id";
            migrationBuilder.Sql(createCDCommand);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string dropSCrCommand = @"DROP VIEW StudentCredits";
            migrationBuilder.Sql(dropSCrCommand);

            string dropCDCommand = @"DROP VIEW CourseDetails";
            migrationBuilder.Sql(dropCDCommand);
        }
    }
}
