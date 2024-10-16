﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dto.Quizresultsdto;
using OnlineEducationPlatform.BLL.Dto.StudentDto;
using OnlineEducationPlatform.BLL.handleresponse;
using OnlineEducationPlatform.BLL.Manager.StudentManager;

namespace OnlineEducationPlatform.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly Istudentmanager _studentmanager;

        public StudentController(Istudentmanager studentmanager)
        {
            _studentmanager = studentmanager;
        }

        [HttpGet("GetAllStudents")]

        public async Task<ActionResult<ServiceResponse<studentreaddto>>> GetAll()
        {
            var serviceResponse = await _studentmanager.GetAllStudentsAsync();
           
            if (serviceResponse.Success)
            {
                return Ok(serviceResponse);
            }

            else
            {


                return BadRequest(serviceResponse.Message);

            }

        }
        [HttpGet("GetAllStudents/{StudentId}")]
        public async Task<ActionResult<ServiceResponse<studentreaddto>>> GetById(string StudentId)
        {
            var serviceResponse = await _studentmanager.Getstudentbyid(StudentId);
            if (serviceResponse.Success)
            {
                return Ok(serviceResponse);
            }
           
           else
            {


                return BadRequest(serviceResponse.Message);

            }

        }
        [HttpDelete("SoftDeleteStudent/{StudentId}")]
        //  [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<bool>>> SoftDeleteStudent(string StudentId)
        {

            var response = await _studentmanager.softdeleteStudent(StudentId);
            if (response.Success)
            {
                return Ok(response.Message);
            }
            else
            {


                return BadRequest(response.Message);

            }


        }
    }
}