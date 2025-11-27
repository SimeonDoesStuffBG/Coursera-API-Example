using Coursera_Exercise.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.Xml;

namespace Coursera_Exercise.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private static List<Student> students = new List<Student>{ 
            

        };

        [HttpGet]
        public ActionResult<List<Student>> GetStudents()
        {
            return Ok(students);
        }

        [HttpGet("{pin}")]
        public ActionResult<Student> GetStudentById(string pin)
        {
            Student? student = students.FirstOrDefault(s => s.PIN == pin);
            if(student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public ActionResult<Student> CreateStudent(Student newStudent)
        {
            if (newStudent == null)
                return BadRequest();
            if (students.FirstOrDefault(s => s.PIN == newStudent.PIN) != null)
                return Conflict();

            students.Add(newStudent);
            return CreatedAtAction(nameof(GetStudentById), new { pin=newStudent.PIN }, newStudent);
        }

        [HttpPut("{pin}")]
        public IActionResult UpdateStudent(string pin, Student editedStudent)
        {
            Student? student = students.FirstOrDefault(s => s.PIN == pin);
            if(student == null)
            {
                return NotFound();
            }
            if (students.FirstOrDefault(s => s.PIN == editedStudent.PIN) != null && student.PIN != editedStudent.PIN)
                return Conflict();

            student.PIN = editedStudent.PIN;
            student.First_name = editedStudent.First_name;
            student.Last_name = editedStudent.Last_name;
            student.Time_created = editedStudent.Time_created;
            return NoContent();
        }

        [HttpDelete("{pin}")]
        public IActionResult DeleteStudent(string pin)
        {
            Student? student = students.FirstOrDefault(s => s.PIN == pin);
            if (student == null)
                return NotFound();

            students.Remove(student);
            return NoContent();
        }
    }
}
