using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dto.TestDto;
using OnlineEducationPlatform.BLL.Services.ExamService;
using OnlineEducationPlatform.BLL.Services.QuizService;
using OnlineEducationPlatform.DAL.Data.Models;

namespace OnlineEducationPlatform.Api.Controllers.Exam
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _context;

        public ExamController(IExamService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamReadDto>>> GetExam()
        {
            return Ok(_context.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExamReadDto>> GetExamById(int id)
        {
            var quiz = _context.GetById(id);
            if (quiz == null)
            {
                return NotFound();
            }
            return quiz;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ExamAddDto>> CreateExam(ExamAddDto quiz)
        {
            if (quiz is not null)
            {
                _context.Add(quiz);
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateExam(int id, ExamUpdateDto quiz)
        {
            if (id != quiz.Id)
            {
                return BadRequest();
            }

            _context.Update(quiz);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            _context.Delete(id);
            return NoContent();
        }
    }
}
