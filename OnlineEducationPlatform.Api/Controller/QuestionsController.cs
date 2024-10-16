using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.BLL.Manager;
using OnlineEducationPlatform.BLL.Manager.Questionmanager;

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
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _questionManager.GetAllAsync());
        }
        [HttpGet]
        [Route("Exam")]
        public async Task<ActionResult> GetAllExamAsync()
        {
            return Ok(await _questionManager.GetAllExamAsync());
        }
        [HttpGet]
        [Route("Quiz")]
        public async Task<ActionResult> GetAllQuizAsync()
        {
            return Ok(await _questionManager.GetAllQuizAsync());
        }
        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult> GetByIdAsync(int Id)
        {
            var question = await _questionManager.GetByIdAsync(Id);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }
        [HttpPost]
        [Route("Quiz")]
        public async Task<ActionResult> AddQuizAsync(QuestionQuizAddDto questionQuizAddDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _questionManager.AddQuizAsync(questionQuizAddDto);
            return NoContent();
        }
        [HttpPost]
        [Route("Exam")]
        public async Task<ActionResult> AddExamAsync(QuestionExamAddDto questionExamAddDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _questionManager.AddExamAsync(questionExamAddDto);
            return NoContent();
        }
        [HttpPut]
        [Route("{Id}")]
        public async Task<ActionResult> UpdateAsync(int Id, QuestionUpdateDto questionUpdateDto)
        {
            if (Id != questionUpdateDto.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }
            await _questionManager.UpdateAsync(questionUpdateDto);
            return NoContent();
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int Id)
        {
            await _questionManager.DeleteAsync(Id);
            return NoContent();
        }
    }
}