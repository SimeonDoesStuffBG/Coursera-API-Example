using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Coursera_Exercise.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "First_name", "Last_name", "Time_created" },
                values: new object[,]
                {
                    { 1, "Gandalf", "The Gray", new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Moiraine", "Sedai", new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Leto Atreides", "The Second The Second", new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Archangel", "Michael", new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Eda", "Clawthorne", new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "PIN", "First_name", "Last_name", "Time_created" },
                values: new object[,]
                {
                    { "hjPe23Lmn4", "Rand", "al'Thor", new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "lkas45mkp6", "Frodo", "Baggins", new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "mnet56sda7", "James", "Holden", new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "oopq34dda5", "Paul", "Atreides", new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "sahh12KJF3", "John", "Doe", new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Credit", "Instructor_id", "Name", "Time_created", "Total_time" },
                values: new object[,]
                {
                    { 1, (short)20, 3, "Programming basics", new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)23 },
                    { 2, (short)1, 3, "Object orianted programming", new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)13 },
                    { 3, (short)22, 2, "Parody", new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)22 },
                    { 4, (short)9, 5, "Creative Writing", new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)43 },
                    { 5, (short)23, 1, "Elvish", new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)34 }
                });

            migrationBuilder.InsertData(
                table: "StudentsCourse",
                columns: new[] { "Course_id", "Student_pin", "Completion_Date" },
                values: new object[,]
                {
                    { 1, "hjPe23Lmn4", null },
                    { 3, "hjPe23Lmn4", null },
                    { 4, "hjPe23Lmn4", new DateOnly(2023, 12, 9) },
                    { 5, "hjPe23Lmn4", null },
                    { 1, "lkas45mkp6", null },
                    { 3, "lkas45mkp6", null },
                    { 1, "mnet56sda7", null },
                    { 2, "mnet56sda7", null },
                    { 3, "mnet56sda7", new DateOnly(2023, 12, 9) },
                    { 4, "mnet56sda7", new DateOnly(2023, 12, 9) },
                    { 5, "mnet56sda7", null },
                    { 4, "oopq34dda5", new DateOnly(2023, 12, 9) },
                    { 2, "sahh12KJF3", null },
                    { 3, "sahh12KJF3", new DateOnly(2023, 12, 9) },
                    { 4, "sahh12KJF3", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StudentsCourse",
                keyColumns: new[] { "Course_id", "Student_pin" },
                keyValues: new object[] { 1, "hjPe23Lmn4" });

            migrationBuilder.DeleteData(
                table: "StudentsCourse",
                keyColumns: new[] { "Course_id", "Student_pin" },
                keyValues: new object[] { 3, "hjPe23Lmn4" });

            migrationBuilder.DeleteData(
                table: "StudentsCourse",
                keyColumns: new[] { "Course_id", "Student_pin" },
                keyValues: new object[] { 4, "hjPe23Lmn4" });

            migrationBuilder.DeleteData(
                table: "StudentsCourse",
                keyColumns: new[] { "Course_id", "Student_pin" },
                keyValues: new object[] { 5, "hjPe23Lmn4" });

            migrationBuilder.DeleteData(
                table: "StudentsCourse",
                keyColumns: new[] { "Course_id", "Student_pin" },
                keyValues: new object[] { 1, "lkas45mkp6" });

            migrationBuilder.DeleteData(
                table: "StudentsCourse",
                keyColumns: new[] { "Course_id", "Student_pin" },
                keyValues: new object[] { 3, "lkas45mkp6" });

            migrationBuilder.DeleteData(
                table: "StudentsCourse",
                keyColumns: new[] { "Course_id", "Student_pin" },
                keyValues: new object[] { 1, "mnet56sda7" });

            migrationBuilder.DeleteData(
                table: "StudentsCourse",
                keyColumns: new[] { "Course_id", "Student_pin" },
                keyValues: new object[] { 2, "mnet56sda7" });

            migrationBuilder.DeleteData(
                table: "StudentsCourse",
                keyColumns: new[] { "Course_id", "Student_pin" },
                keyValues: new object[] { 3, "mnet56sda7" });

            migrationBuilder.DeleteData(
                table: "StudentsCourse",
                keyColumns: new[] { "Course_id", "Student_pin" },
                keyValues: new object[] { 4, "mnet56sda7" });

            migrationBuilder.DeleteData(
                table: "StudentsCourse",
                keyColumns: new[] { "Course_id", "Student_pin" },
                keyValues: new object[] { 5, "mnet56sda7" });

            migrationBuilder.DeleteData(
                table: "StudentsCourse",
                keyColumns: new[] { "Course_id", "Student_pin" },
                keyValues: new object[] { 4, "oopq34dda5" });

            migrationBuilder.DeleteData(
                table: "StudentsCourse",
                keyColumns: new[] { "Course_id", "Student_pin" },
                keyValues: new object[] { 2, "sahh12KJF3" });

            migrationBuilder.DeleteData(
                table: "StudentsCourse",
                keyColumns: new[] { "Course_id", "Student_pin" },
                keyValues: new object[] { 3, "sahh12KJF3" });

            migrationBuilder.DeleteData(
                table: "StudentsCourse",
                keyColumns: new[] { "Course_id", "Student_pin" },
                keyValues: new object[] { 4, "sahh12KJF3" });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "PIN",
                keyValue: "hjPe23Lmn4");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "PIN",
                keyValue: "lkas45mkp6");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "PIN",
                keyValue: "mnet56sda7");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "PIN",
                keyValue: "oopq34dda5");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "PIN",
                keyValue: "sahh12KJF3");

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
