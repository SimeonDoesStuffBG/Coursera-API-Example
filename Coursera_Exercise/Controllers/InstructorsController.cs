using Coursera_Exercise.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coursera_Exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
       private static List<Instructor> instructors = new List<Instructor>
       {
           
       };

        [HttpGet]
        public ActionResult<List<Instructor>> GetInstructors()
        {
            return Ok(instructors);
        }

        [HttpGet("{id}")]
        public ActionResult<Instructor> GetInstructorByID (int id)
        {
            Instructor? instructor = instructors.FirstOrDefault(i => i.Id == id);
            if (instructor == null)
                return NotFound();

            return Ok(instructor);
        }

        [HttpPost]
        public ActionResult<Instructor> CreateInstructor(Instructor newInstructor)
        {
            if(newInstructor == null)
            {
                return BadRequest();
            }
            if (instructors.FirstOrDefault(i => i.Id == newInstructor.Id)!=null)
            {
                return Conflict();
            }

            instructors.Add(newInstructor);
            return CreatedAtAction(nameof(GetInstructorByID), new { id = newInstructor.Id }, newInstructor);
        }

        [HttpPut("{id}")]
        public IActionResult EditInstructor(int id, Instructor editedInstructor)
        {
            Instructor? instructor = instructors.FirstOrDefault(i=>i.Id==id);
            if(instructor == null)
            {
                return NotFound();
            }
            if(instructors.FirstOrDefault(i=>i.Id==editedInstructor.Id)!=null && instructor.Id != editedInstructor.Id)
            {
                return Conflict();
            }

            instructor.Id = editedInstructor.Id;
            instructor.First_name = editedInstructor.First_name;
            instructor.Last_name = editedInstructor.Last_name;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInstructor(int id)
        {
            Instructor? instructor = instructors.FirstOrDefault(i => i.Id == id);
            if (instructor == null)
            {
                return NotFound();
            }

            instructors.Remove(instructor);
            return NoContent();
        }
    }
}
