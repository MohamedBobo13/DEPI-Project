using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dto.QuestionDto;
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
        [HttpGet]
        [Route("Exam")]
        public async Task<ActionResult> GetAllExamAsync()
        {
            return Ok(await _questionManager.GetAllExamAsync());
        }
        [HttpPost]
        [Route("Exam")]
        public async Task<ActionResult> AddExamAsync(QuestionExamAddDto questionExamAddDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _questionManager.ExamIdExist(questionExamAddDto.ExamId))
            {
                return BadRequest("Exam Id Not Valid");
            }
            await _questionManager.AddExamAsync(questionExamAddDto);
            return NoContent();
        }
        [HttpPut]
        [Route("Exam/{Id}")]
        public async Task<ActionResult> UpdateExamAsync(int Id, QuestionExamUpdateDto questionExamUpdateDto)
        {
            if (Id != questionExamUpdateDto.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }
            if (!await _questionManager.ExamIdExist(questionExamUpdateDto.ExamId))
            {
                return BadRequest("Exam Id Not Valid");
            }
            await _questionManager.UpdateExamAsync(questionExamUpdateDto);
            return NoContent();
        }
        [HttpGet]
        [Route("Quiz")]
        public async Task<ActionResult> GetAllQuizAsync()
        {
            return Ok(await _questionManager.GetAllQuizAsync());
        }
        [HttpPost]
        [Route("Quiz")]
        public async Task<ActionResult> AddQuizAsync(QuestionQuizAddDto questionQuizAddDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _questionManager.QuizIdExist(questionQuizAddDto.QuizId))
            {
                return BadRequest("Quiz Id Not Valid");
            }
            await _questionManager.AddQuizAsync(questionQuizAddDto);
            return NoContent();
        }
        
        [HttpPut]
        [Route("Quiz/{Id}")]
        public async Task<ActionResult> UpdateQuizAsync(int Id, QuestionQuizUpdateDto questionQuizUpdateDto)
        {
            if (Id != questionQuizUpdateDto.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }
            if (!await _questionManager.QuizIdExist(questionQuizUpdateDto.QuizId))
            {
                return BadRequest("Quiz Id Not Valid");
            }
            await _questionManager.UpdateQuizAsync(questionQuizUpdateDto);
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