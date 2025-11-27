using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coursera_Exercise.Migrations
{
    /// <inheritdoc />
    public partial class CreateStoredProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string GetCredits = @"CREATE PROCEDURE GetStudentCredits AS
                                            BEGIN
                                                SELECT * FROM StudentCredits
                                            END";
            migrationBuilder.Sql(GetCredits);

            string GetDetaild = @"CREATE PROCEDURE GetCourseDetails @StudentPIN nchar(10) AS
                                            BEGIN 
                                               SELECT CourseDetails.*
                                                FROM CourseDetails
                                                RIGHT JOIN StudentsCourse
                                                ON CourseDetails.Course_Id = StudentsCourse.Course_id
                                                WHERE StudentsCourse.Student_pin = @StudentPIN AND StudentsCourse.Completion_Date IS NOT NULL 
                                            END";
            migrationBuilder.Sql(GetDetaild);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
