using Coursera_Exercise.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coursera_Exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private static List<Course> courses = new List<Course>
        {
            
        };

        [HttpGet]
        public ActionResult<List<Course>> GetCourses()
        {
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public ActionResult<Course> GetCourseByID(int id)
        {
            Course? course = courses.FirstOrDefault(c => c.Id == id);
            if(course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPost]
        public ActionResult<Course> CreateCourse(Course newCourse)
        {
            if(newCourse == null)
            {
                return NotFound();
            }
            if(courses.FirstOrDefault(c=>c.Id == newCourse.Id)!=null)
            {
                return Conflict();
            }

            courses.Add(newCourse);
            return CreatedAtAction(nameof(GetCourseByID), new { id = newCourse.Id }, newCourse);
        }

        [HttpPut("{id}")]
        public IActionResult EditCourse(int id, Course editedCourse)
        {
            Course? course = courses.FirstOrDefault(c => c.Id == id);
            if(course == null)
            {
                return NotFound();
            }
            if(courses.FirstOrDefault(c=>c.Id== editedCourse.Id)!=null && editedCourse.Id != course.Id)
            {
                return Conflict();
            }

            course.Id = editedCourse.Id;
            course.Name = editedCourse.Name;
            course.Instructor_id = editedCourse.Instructor_id;
            course.Total_time = editedCourse.Total_time;
            course.Credit = editedCourse.Credit;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            Course? course = courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            courses.Remove(course);
            return NoContent();
        }
    }
}
