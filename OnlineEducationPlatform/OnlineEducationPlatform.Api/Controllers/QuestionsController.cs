using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.BLL.Manager;

namespace OnlineEducationPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionManager _questionManager;


        public QuestionsController(IQuestionManager questionManager)
        {
            _questionManager = questionManager;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_questionManager.GetAll());
        }
        [HttpGet]
        [Route("{Id}")]
        public ActionResult GetById(int Id)
        {
            return Ok(_questionManager.GetById(Id));
        }
        [HttpPost]
        public ActionResult Add(QuestionAddDto questionAddDto)
        {
            _questionManager.Add(questionAddDto);
            return NoContent();
        }
        [HttpPut]
        [Route("{Id}")]
        public ActionResult Update(int Id, QuestionUpdateDto questionUpdateDto)
        {
            if (Id != questionUpdateDto.Id)
            {
                return BadRequest();
            }
            _questionManager.Update(questionUpdateDto);
            return NoContent();
        }
        [HttpDelete]
        public ActionResult Delete(int Id)
        {
            _questionManager.Delete(Id);
            return NoContent();
        }
    }
}
