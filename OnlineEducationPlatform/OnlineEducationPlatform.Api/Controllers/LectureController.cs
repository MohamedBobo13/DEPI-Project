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
        //Instructor and Student can get all Lectures
        public async Task<IActionResult> GetAllLectures()
        {
            var lectures = await _lectureManager.GetAllAsync();
            if (lectures != null)
            {
                return Ok(lectures);
            }
            return NotFound();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetLecture(int id)
        {
            var lecture = await _lectureManager.GetByIdAsync(id);
            if (lecture != null)
            {
                return Ok(lecture);
            }
            return NotFound();
        }



        [HttpDelete("{id:int}")]
        //Instructor only can delete lecture
        public async Task<ActionResult> RemoveLecture(int id)
        {
            var lecture = await _lectureManager.GetByIdAsync(id);
            if (lecture != null)
            {
                var IsDeleted = await _lectureManager.DeleteAsync(id);
                if (IsDeleted)
                {
                    return Ok("Lecture Deleted Successfully");
                }
                return StatusCode(500, "An error occurred while deleting the lecture.");

            }
            return NotFound();
        }
        [HttpPost]
        //Instructor only can add Lecture
        public async Task<ActionResult<LectureAddDto>> AddLecture(LectureAddDto lectureAddDto)
        {
            var lecture = _lectureManager.AddAsync(lectureAddDto);
            if (lecture != null)
            {
                return Ok("Addition Succeeded");

            }
            return BadRequest("Failed To Add Lecture");

        }
        [HttpPut("{id:int}")]
        //Insturctor only can update Lecture
        public async Task<ActionResult> UpdateLecture(int id, LectureUpdateDto lectureUpdateDto)
        {
            if (id != lectureUpdateDto.Id)
            {
                return BadRequest("Id is not Identical");
            }
            var course = await _lectureManager.UpdateAsync(lectureUpdateDto);
            return Ok("Lecture is Updaded");

        }
    }
}
