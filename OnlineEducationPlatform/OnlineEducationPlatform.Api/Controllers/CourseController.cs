using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.BLL.Manager;

namespace OnlineEducationPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseManager _courseManager;
      

        public CourseController(ICourseManager courseManager)
        {
            _courseManager = courseManager;
           
        }
        [HttpGet]
        //Instructor and Student can get all Courses
        public async Task<IActionResult> GetAllCourses()
        {
            var courses =await _courseManager.GetAllAsync();
            if (courses != null)
            {
                return Ok(courses);
            }
            return NotFound();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetCourse(int id)
        {
            var course =await _courseManager.GetByIdAsync(id);
            if (course != null)
            {
                return Ok(course);
            }
            return NotFound();
        }



        [HttpDelete("{id:int}")]
        //Instructor only can delete course
        public async Task<ActionResult> RemoveCourse(int id)
        {
            var course = await _courseManager.GetByIdAsync(id);
            if ( course != null )
            {
                var IsDeleted=await _courseManager.DeleteAsync(id);
                if (IsDeleted)
                {
                    return Ok("Course Deleted Successfully");
                }
                return StatusCode(500, "An error occurred while deleting the course.");

            }
            return NotFound();
        }
        [HttpPost]
        //Instructor only can add course
        public async Task<ActionResult<CourseAddDto>> AddCourse(CourseAddDto courseAddDto)
        {
            var course = _courseManager.AddAsync(courseAddDto);
            if (course != null)
            {
                return Ok("Addition Succeeded");

            }
            return BadRequest("Failed To Add Course");

        }
        [HttpPut("{id:int}")]
        //Insturctor only can update course
        public async Task<ActionResult> UpdateCourse(int id,CourseUpdateDto courseUpdateDto)
        {
            if (id != courseUpdateDto.Id)
            {
                return BadRequest("Id is not Identical");
            }
            var course=await _courseManager.UpdateAsync(courseUpdateDto);
            return Ok("Course is Updaded");

        }

    }
}
