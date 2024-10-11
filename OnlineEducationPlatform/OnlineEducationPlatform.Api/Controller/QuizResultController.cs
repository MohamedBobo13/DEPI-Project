using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dto;
using OnlineEducationPlatform.BLL.handleresponse;
using OnlineEducationPlatform.BLL.Manager;
using OnlineEducationPlatform.DAL.Data.Models;

namespace OnlineEducationPlatform.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizResultController : ControllerBase
    {
        private readonly IQuizResultManager _quizResultManager;

        public QuizResultController(IQuizResultManager quizResultManager)
        {
            _quizResultManager = quizResultManager;
        }
        [HttpGet("GetStudentResultby/{StudentId}/{QuizId}")]
        public async Task<ActionResult<ServiceResponse<QuizResult>>> GetStudentResult(string StudentId ,int QuizId)
        {

            var response = await _quizResultManager.GetQuizResultAsync(StudentId,QuizId);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {


                return BadRequest(response);

            }

        }


    }
}
