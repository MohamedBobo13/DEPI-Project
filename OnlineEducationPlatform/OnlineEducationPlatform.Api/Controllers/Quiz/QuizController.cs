using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.BLL.Dto.TestDto;
using OnlineEducationPlatform.BLL.Services.QuizService;

namespace OnlineEducationPlatform.Api.Controllers.Quiz
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _context;

        public QuizController(IQuizService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuizReadDto>>> GetQuizzes()
        {
            return Ok(_context.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuizReadDto>> GetQuiz(int id)
        {
            var quiz = _context.GetById(id);
            if (quiz == null)
            {
                return NotFound();
            }
            return quiz;
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<QuizAddDto>> CreateQuiz(QuizAddDto quiz)
        {
            if(quiz is not null)
            {
                _context.Add(quiz);
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateQuiz(int id, QuizUpdateDto quiz)
        {
            if (id != quiz.Id)
            {
                return BadRequest();
            }

            _context.Update(quiz);
             return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteQuiz(int id)
        {
            _context.Delete(id);
            return NoContent();
        }
    }
}
