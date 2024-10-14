using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.BLL.Manager;
using OnlineEducationPlatform.DAL.Data.Models;

namespace OnlineEducationPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerResultsController : ControllerBase
    {
        private readonly IAnswerResultManager _answerResultManager;

        public AnswerResultsController(IAnswerResultManager answerResultManager)
        {
            _answerResultManager = answerResultManager;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_answerResultManager.GetAll());
        }
        [HttpGet]
        [Route("{Id}")]
        public ActionResult GetById(int Id)
        {
            return Ok(_answerResultManager.GetById(Id));
        }
        [HttpPost]
        public ActionResult Add(AnswerResultAddDto answerResultAddDto)
        {
            _answerResultManager.Add(answerResultAddDto);
            return NoContent();
        }
        [HttpPut]
        [Route("{Id}")]
        public ActionResult Update(int Id, AnswerResultUpdateDto answerResultUpdateDto)
        {
            if (Id != answerResultUpdateDto.Id)
            {
                return BadRequest();
            }
            _answerResultManager.Update(answerResultUpdateDto);
            return NoContent();
        }
        [HttpDelete]
        public ActionResult Delete(int Id)
        {
            _answerResultManager.Delete(Id);
            return NoContent();
        }
    }
}
