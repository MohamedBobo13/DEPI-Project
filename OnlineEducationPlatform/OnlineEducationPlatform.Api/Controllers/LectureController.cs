using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.BLL.Manager;

namespace OnlineEducationPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectureController : ControllerBase
    {
        private readonly ILectureManager _lectureManager;

        public LectureController(ILectureManager lectureManager)
        {
            _lectureManager = lectureManager;
        }
        [HttpGet]
        public IActionResult GetAllLectuers()
        {
            return Ok(_lectureManager.GetAll());
        }
        [HttpGet("{id:int}")]

        public IActionResult GetById(int id)
        {
            return Ok(_lectureManager.GetById(id));
        }

        [HttpDelete("{id:int}")]
        public IActionResult RemoveLecture(int id)
        {
            _lectureManager.Delete(id);
            return StatusCode(204);
        }
        [HttpPost]
        public IActionResult AddLecture(LectureAddDto lectureAddDto)
        {
            _lectureManager.Add(lectureAddDto);
            return Created();
        }
        [HttpPut]
        public IActionResult UpdateLecture(LectureUpdateDto lectureUpdateDto)
        {
            _lectureManager.Update(lectureUpdateDto);
            return StatusCode(204);
        }
    }
}
