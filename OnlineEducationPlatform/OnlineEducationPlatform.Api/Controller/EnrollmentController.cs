using Azure;
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
    public class EnrollmentController : ControllerBase
    {
        private readonly IenrollmentManager _enrollmentmanager;

        public EnrollmentController(IenrollmentManager enrollmentmanager)
        {
            _enrollmentmanager = enrollmentmanager;
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<EnrollmentDtowWithStatusanddDate>>> CreateEnrollment([FromBody] EnrollmentDto enrollmentDto)
        {

             var response = await _enrollmentmanager.CreateEnrollmentAsync(enrollmentDto);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                 
                
                 return BadRequest(response);
               
            }


        }
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteEnrollment([FromBody] EnrollmentDto enrollmentDto)
        {

            var response = await _enrollmentmanager.UnenrollFromCourseByStudentAndCourseIdAsync(enrollmentDto);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {


                return BadRequest(response);

            }


        }
        [HttpGet("GetAllByCourseId/{CourseId}")]
        public async Task<ActionResult<ServiceResponse<EnrollmentDtoForRetriveAllEnrollmentsInCourse>>> GetAllEnrollmentsByCourseId(int CourseId)
        {
            var response = await _enrollmentmanager.GetEnrollmentsByCourseIdAsync(CourseId);

            if (CourseId <= 0)
            {
                return BadRequest("Invalid course ID.");
            }
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {


                return BadRequest(response);

            }


        }
        [HttpGet("GetAllByStudentId/{StudentId}")]
        public async Task<ActionResult<ServiceResponse<EnrollmentDtoForRetriveAllEnrollmentsInCourse>>> GetEnrollmentsByStudentIdAsync(string StudentId)
        {
            var response = await _enrollmentmanager.GetEnrollmentsByStudentIdAsync(StudentId);

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


                return BadRequest(response);

            }


        }


        //[HttpPost]
        //public async Task<IActionResult> CreateEnrollment([FromBody] EnrollmentDto enrollmentDto)
        //{


        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var response = new ServiceResponse<Enrollment>();
        //   // Save changes

        //    var result = await _enrollmentmanager.CreateEnrollmentAsync(enrollmentDto);
        //    if (result)
        //    {


        //    }

        //    return BadRequest("Unable to create enrollment");
        //}
        //[HttpGet("{id}")]
        //public async Task<ActionResult<EnrollmentDto>> GetEnrollmentById(int id)
        //{
        //    var enrollment = await _enrollmentmanager.GetEnrollmentByIdAsync(id);

        //    if (enrollment == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(enrollment);
        //}

    }
}
