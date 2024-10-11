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
        public IActionResult GetAllCourses()
        {
            return Ok(_courseManager.GetAll());
        }
        [HttpGet("{id:int}")]

        public IActionResult GetById(int id)
        {
            return Ok(_courseManager.GetById(id));
        }

        [HttpDelete("{id:int}")]
        public IActionResult RemoveCourse(int id)
        {
            _courseManager.Delete(id);
            return Ok();
        }
        [HttpPost]
        public IActionResult AddCourse(CourseAddDto courseAddDto)
        {
            _courseManager.Add(courseAddDto);
            return Created();
        }
        [HttpPut]
        public IActionResult UpdateCourse(CourseUpdateDto courseUpdateDto)
        {
            _courseManager.Update(courseUpdateDto);
            return Ok();
        }

    }
}
