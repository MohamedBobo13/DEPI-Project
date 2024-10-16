using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dto.ExamResultDto;
using OnlineEducationPlatform.BLL.Dto.Quizresultsdto;
using OnlineEducationPlatform.BLL.handleresponse;
using OnlineEducationPlatform.BLL.Manager.ExamResultmanager;
using OnlineEducationPlatform.DAL.Data.Models;

namespace OnlineEducationPlatform.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamResultController : ControllerBase
    {
        private readonly IExamResultmanager _examResultmanager;

        public ExamResultController(IExamResultmanager examResultmanager)
        {
            _examResultmanager = examResultmanager;
        }

        [HttpGet("GetAllExamResults")]

        public async Task<ActionResult<ServiceResponse<Examresultreaddto>>> GetAll()
        {
            var serviceResponse = await _examResultmanager.GetAllExamResults();
            if (serviceResponse.Success && serviceResponse.Message == "There Are No Exam Results yet !!")
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


        [HttpGet("GetStudentResultby/{StudentId}/{ExamId}")]
        public async Task<ActionResult<ServiceResponse<QuizResult>>> GetStudentResult(string StudentId, int ExamId)
        {

            var response = await _examResultmanager.GetExamResultAsync(StudentId, ExamId);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {


                return BadRequest(response);

            }

        }
        [HttpPost("AddExamResult")]
        //   [Authorize(Roles ="Admin")]
        public async Task<ActionResult<ServiceResponse<Examresultwithoutiddto>>> CreateExamResult([FromBody] Examresultwithoutiddto examresultadddto)
        {

            var response = await _examResultmanager.CreateexamresultAsync(examresultadddto);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {


                return BadRequest(response);

            }


        }
        [HttpDelete("SoftDeleteExamResult/{StudentId}/{ExamId}")]
        //  [Authorize(Roles = "Admin")]

        public async Task<ActionResult<ServiceResponse<bool>>> SoftDeleteExamresult(string StudentId, int ExamId)
        {

            var response = await _examResultmanager.softdeleteexamresult(StudentId, ExamId);
            if (response.Success)
            {
                return Ok(response.Message);
            }
            else
            {


                return BadRequest(response.Message);

            }


        }

        [HttpDelete("HardDeleteExamResult/{studentId}/{ExamId}")]
        //  [Authorize(Roles = "Admin")]

        public async Task<ActionResult<ServiceResponse<bool>>> HardDeleteExamresult(string studentId, int ExamId)
        {

            var response = await _examResultmanager.HardDeleteExamresulttByStudentAndquizsync(studentId, ExamId);
            if (response.Success)
            {
                return Ok(response.Message);
            }

            else
            {
                return BadRequest(response.Message);
            }


        }
        [HttpGet("GetAllSoftDeletedExamResults")]

        public async Task<ActionResult<ServiceResponse<quizresultwithoutiddto>>> GetAllSoftDeletedExamresults()
        {
            var serviceResponse = await _examResultmanager.GetAllSoftDeletedexamresultsAsync();
            if (serviceResponse.Success && serviceResponse.Message == "There Are No Soft Deleted Exam results yet !!")
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
        [HttpPut("UpdateExamResult/{Id}")]

        public async Task<ActionResult<ServiceResponse<bool>>> UpdateExamresult(int Id, updateexamresultdto examresultupdatedto)
        {
            if (Id != examresultupdatedto.id) { return BadRequest(new { message = "Id is not identical" }); }

            var serviceResponse = await _examResultmanager.updateexamresultbyid(examresultupdatedto);

            if (serviceResponse.Success)
            {
                return Ok(serviceResponse.Message);
            }

            else
            {


                return BadRequest(serviceResponse.Message);

            }

        }
        [HttpGet("GetAllByStudentId/{StudentId}")]
        public async Task<ActionResult<ServiceResponse<quizresultreaddto>>> GetExamResultsByStudentIdAsync(string StudentId)
        {
            var response = await _examResultmanager.GetStudentresultssByStudentIdAsync(StudentId);

            if (int.Parse(StudentId) <= 0)
            {
                return BadRequest("Invalid Student Id.");
            }
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {


                return BadRequest(response.Message);

            }


        }
        [HttpGet("GetAllByExamId/{QuizId}")]
        // [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<quizresultreaddto>>> GetExamResultsByquizIdAsync(int examid)
        {
            var response = await _examResultmanager.GetstudentresultsByExamIdAsync(examid);

            if (examid <= 0)
            {
                return BadRequest("Invalid Exam ID.");
            }
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {


                return BadRequest(response.Message);

            }


        }
    }
}
