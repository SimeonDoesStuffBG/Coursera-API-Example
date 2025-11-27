using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Coursera_Exercise.Models
{
    [PrimaryKey(nameof(PIN))]
    public class Student
    {
        [DataType("nchar(10)")]
        public string PIN { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public DateTime Time_created { get; set; } = DateTime.Now;
    }
}
