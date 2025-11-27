using Coursera_Exercise.Data;
using Coursera_Exercise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace Coursera_Exercise.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly CourseraExerciseContext _context;

        public StudentsController(CourseraExerciseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        { 
            return Ok(await _context.Students.ToListAsync());
        }

        [HttpGet("{pin}")]
        public async Task<ActionResult<Student>> GetStudentByPIN(string pin)
        {
            Student? student = await _context.Students.FindAsync(pin);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student newStudent)
        {
            if (newStudent == null)
            {
                return BadRequest();
            }
           
            _context.Students.Add(newStudent);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStudentByPIN), new { pin=newStudent.PIN }, newStudent);
        }

        [HttpPut("{pin}")]
        public async Task<IActionResult> UpdateStudent(string pin, Student editedStudent)
        {
            Student? student = await _context.Students.FindAsync(pin);
            if(pin != editedStudent.PIN)
            {
                return Conflict();
            }
            if(student == null)
            {
                return NotFound();
            }
            
            student.First_name = editedStudent.First_name;
            student.Last_name = editedStudent.Last_name;
            student.Time_created = editedStudent.Time_created;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{pin}")]
        public async Task<IActionResult> DeleteStudent(string pin)
        {
            Student? student = await _context.Students.FindAsync(pin);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
