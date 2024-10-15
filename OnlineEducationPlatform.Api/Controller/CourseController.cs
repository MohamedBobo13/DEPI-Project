using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dto.CourseDto;
using OnlineEducationPlatform.BLL.Manager.CourseManager;

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
        public ActionResult GetAllCourses()
        {
            var AllCourses = _courseManager.GetAll();
            if (AllCourses != null)
            {
                return Ok(AllCourses);
            }
            return NotFound();
        }
      
        [HttpGet("{id:int}")]
        //Instructor and Student can get course
        public ActionResult GetById(int id)
        {
            var course= _courseManager.GetById(id);
            if (course != null)
            {
                return Ok(course);
            }
            return NotFound();
        }

        [HttpDelete("{id:int}")]
        //Instructor only can delete course
        public ActionResult RemoveCourse(int id)
        {
            _courseManager.Delete(id);
            return Ok();
        }
        [HttpPost]
        //Instructor only can add course
        public ActionResult AddCourse(CourseAddDto courseAddDto)
        {
            _courseManager.Add(courseAddDto);
            return Created();
        }
        [HttpPut]
        //Insturctor only can update course
        public ActionResult UpdateCourse(CourseUpdateDto courseUpdateDto)
        {
            _courseManager.Update(courseUpdateDto);
            return Ok();
        }

    }
}
