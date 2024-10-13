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
        // Instrutor and Student can get All Lecture
        public ActionResult GetAllLectuers()
        {
            var AllLectures=_lectureManager.GetAll();
            if (AllLectures != null)
            {
                return Ok(AllLectures);
            }
            return NotFound();
        }
        [HttpGet("{id:int}")]
        //Instructor and Student can get lecture
        public ActionResult GetById(int id)
        {
            var lecture= _lectureManager.GetById(id);
            if (lecture != null)
            {
                return Ok(lecture);
            }
            return NotFound();
        }

        [HttpDelete("{id:int}")]
        //Instructor only can delete lecture
        public ActionResult RemoveLecture(int id)
        {
            _lectureManager.Delete(id);
            return Ok();    
        }
        [HttpPost]
        //Instructor only can add lecture
        public ActionResult AddLecture(LectureAddDto lectureAddDto)
        {
            _lectureManager.Add(lectureAddDto);
            return Created();
        }
        [HttpPut]
        //Instructor only can update lecture
        public ActionResult UpdateLecture(LectureUpdateDto lectureUpdateDto)
        {
            _lectureManager.Update(lectureUpdateDto);
            return Ok();
        }
    }
}
