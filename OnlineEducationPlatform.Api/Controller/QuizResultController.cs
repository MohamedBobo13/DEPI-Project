using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dto;
using OnlineEducationPlatform.BLL.Dto.EnrollmentDto;
using OnlineEducationPlatform.BLL.Dto.Quizresultsdto;
using OnlineEducationPlatform.BLL.handleresponse;
using OnlineEducationPlatform.BLL.Manager.quizresultmanager;
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

        [HttpGet("GetAllquizResults")]

        public async Task<ActionResult<ServiceResponse<quizresultreaddto>>> GetAll()
        {
            var serviceResponse = await _quizResultManager.GetAllQuizResults();
            if (serviceResponse.Success && serviceResponse.Message == "There Are No QuizResults yet !!")
            {
                return Ok(serviceResponse.Message);
            }
            else if (serviceResponse.Success)
            {
                return Ok(serviceResponse);
            }

            else
            {


                return BadRequest(serviceResponse.Message);

            }

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
        [HttpDelete("SoftDeleteQuizResult/{StudentId}/{QuizId}")]
        //  [Authorize(Roles = "Admin")]

        public async Task<ActionResult<ServiceResponse<bool>>> SoftDeleteQuizresult(string StudentId, int QuizId)
        {

            var response = await _quizResultManager.softdeletequizresult(StudentId, QuizId);
            if (response.Success)
            {
                return Ok(response.Message);
            }
            else
            {


                return BadRequest(response.Message);

            }


        }
        [HttpDelete("HardDeleteQuizResult/{studentId}/{QuizId}")]
        //  [Authorize(Roles = "Admin")]

        public async Task<ActionResult<ServiceResponse<bool>>> HardDeletequizresult(string studentId, int QuizId)
        {

            var response = await _quizResultManager.HardDeleteEQuizresulttByStudentAndquizsync(studentId, QuizId);
            if (response.Success)
            {
                return Ok(response.Message);
            }

            else
            {
                return BadRequest(response.Message);
            }


        }
        [HttpGet("GetAllSoftDeletedQuizResults")]

        public async Task<ActionResult<ServiceResponse<quizresultwithoutiddto>>> GetAllSoftDeletedQuizresults()
        {
            var serviceResponse = await _quizResultManager.GetAllSoftDeletedQuizresultsAsync();
            if (serviceResponse.Success && serviceResponse.Message == "There Are No Soft Deleted Quiz results yet !!")
            {
                return Ok(serviceResponse.Message);
            }
            else if (serviceResponse.Success)
            {
                return Ok(serviceResponse);
            }

            else
            {


                return BadRequest(serviceResponse.Message);

            }

        }
        [HttpPut("UpdateQuizResult/{Id}")]

        public async Task<ActionResult<ServiceResponse<bool>>> Updatequizresult(int Id, updatequizresultdto quizresultreaddto)
        {
            if (Id != quizresultreaddto.id) { return BadRequest(new { message = "Id is not identical" }); }

            var serviceResponse = await _quizResultManager.updatequizresultbyid(quizresultreaddto);

            if (serviceResponse.Success)
            {
                return Ok(serviceResponse.Message);
            }

            else
            {


                return BadRequest(serviceResponse.Message);

            }

        }

    }
}
