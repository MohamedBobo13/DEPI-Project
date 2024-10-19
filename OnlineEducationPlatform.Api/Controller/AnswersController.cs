using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.BLL.Manager.Answermanager;

namespace OnlineEducationPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IAnswerManager _answerManager;


        public AnswersController(IAnswerManager answerManager)
        {
            _answerManager = answerManager;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_answerManager.GetAll());
        }
        [HttpGet]
        [Route("{Id}")]
        public ActionResult GetById(int Id)
        {
            return Ok(_answerManager.GetById(Id));
        }
        [HttpPost]
        public ActionResult Add(AnswerAddDto answerAddDto)
        {
            _answerManager.Add(answerAddDto);
            return NoContent();
        }
        [HttpPut]
        [Route("{Id}")]
        public ActionResult Update(int Id, AnswerUpdateDto answerUpdateDto)
        {
            if (Id != answerUpdateDto.Id)
            {
                return BadRequest();
            }
            _answerManager.Update(answerUpdateDto);
            return NoContent();
        }
        [HttpDelete]
        public ActionResult Delete(int Id)
        {
            _answerManager.Delete(Id);
            return NoContent();
        }
    }
}
