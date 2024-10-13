using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dto.TestDto;
using OnlineEducationPlatform.BLL.Dto.TestResultDto;
using OnlineEducationPlatform.BLL.Services.QuizResultService;
using OnlineEducationPlatform.BLL.Services.QuizService;

namespace OnlineEducationPlatform.Api.Controllers.QuizResult
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizResultController : ControllerBase
    {
        private readonly IQuizResultService _context;

        public QuizResultController(IQuizResultService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuizResultReadDto>>> GetQuizzes()
        {
            return Ok(_context.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuizResultReadDto>> GetQuiz(int id)
        {
            var quiz = _context.GetById(id);
            if (quiz == null)
            {
                return NotFound();
            }
            return quiz;
        }
    }
}
