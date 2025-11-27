using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coursera_Exercise.Models
{
    [PrimaryKey(nameof(Student_pin), nameof(Course_id))]
    public class StudentCourse
    {
        [ForeignKey(nameof(_Student))]
        [DataType("nchar(10)")]
        public string Student_pin { get; set; }
        [ForeignKey(nameof(_Course))]
        public int Course_id { get; set; }
        public DateOnly? Completion_Date { get; set; } = null!;

        public Course _Course { get; set; }

        public Student _Student { get; set; }
    }
}
