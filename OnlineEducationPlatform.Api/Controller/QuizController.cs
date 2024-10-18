using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dto.TestDto;
using OnlineEducationPlatform.BLL.Services.QuizService;
using OnlineEducationPlatform.DAL.Data.Models;

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

        [HttpGet()]
        public async Task<ActionResult> GetAll()
        {
            var quiz = await _context.GetAllAsync();
            if (quiz !=null)
            {
                return Ok(quiz);
            }
             return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetQuizById(int id)
        {
        var quiz = await _context.GetByIdAsync(id);
        if (quiz == null)
        {
            return NotFound();
        }
        return Ok(quiz);

    }

        [HttpPost]/*
        [Authorize(Roles ="Admin")]*/
        public async Task<ActionResult<QuizAddDto>> CreateQuiz(QuizAddDto quiz)
        {
            var existQuiz = await _context.GetByIdAsync(quiz.Id);
            
            if (existQuiz is null)
            {
                return NotFound();
            }
            await _context.AddAsync(quiz);
            return Ok("Addition Succeeded");
        }

        [HttpPut("{id}")]/*
        [Authorize(Roles = "Admin")]*/
        public async Task<IActionResult> UpdateQuiz(int id, QuizUpdateDto quiz)
        {
            if (id != quiz.Id)
            {
                return BadRequest();
            }
            var existQuiz = await _context.GetByIdAsync(quiz.Id);
            if (existQuiz is null)
            {
                return NotFound();
            }
             await _context.UpdateAsync(quiz);
             return Ok("Updating Succeded");
        }

        [HttpDelete("{id}")]/*
        [Authorize(Roles = "Admin")]*/
        public async Task<IActionResult> DeleteQuiz(int id)
        {
            var existQuiz = await _context.GetByIdAsync(id);
            if (existQuiz is null)
            {
                return NotFound();
            }
             await _context.DeleteAsync(id);
            return Ok("Deletion Succeeded");
        }
    }
}
