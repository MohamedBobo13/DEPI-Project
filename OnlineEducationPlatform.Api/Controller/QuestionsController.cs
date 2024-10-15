﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.BLL.Manager;
using OnlineEducationPlatform.DAL.Data.Models;

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
        public ActionResult GetAll()
        {
            return Ok(_questionManager.GetAll());
        }
        [HttpGet]
        [Route("Exam")]
        public ActionResult GetAllExam()
        {
            return Ok(_questionManager.GetAllExam());
        }
        [HttpGet]
        [Route("Quiz")]
        public ActionResult GetAllQuiz()
        {
            return Ok(_questionManager.GetAllQuiz());
        }
        [HttpGet]
        [Route("{Id}")]
        public ActionResult GetById(int Id)
        {
            return Ok(_questionManager.GetById(Id));
        }
        [HttpPost]
        [Route("Quiz")]
        public ActionResult AddQuiz(QuestionQuizAddDto questionQuizAddDto)
        {
            if (_questionManager.AddQuiz(questionQuizAddDto))
            {


                return NoContent();
            }
            else
            {
                return BadRequest("Quiz Id not exist ");
            }
        }
        [HttpPost]
        [Route("Exam")]
        public ActionResult AddExam(QuestionExamAddDto questionExamAddDto)
        {


            if (_questionManager.Addexam(questionExamAddDto))
            {
                return NoContent();
            }
            else
            {
              return  BadRequest("Exam Id Not Exist");    
            }
        }
        [HttpPut]
        [Route("{Id}")]
        public ActionResult Update(int Id, QuestionUpdateDto questionUpdateDto)
        {
            if (Id != questionUpdateDto.Id)
            {
                return BadRequest();
            }
            _questionManager.Update(questionUpdateDto);
            return NoContent();
        }
        [HttpDelete]
        public ActionResult Delete(int Id)
        {
            _questionManager.Delete(Id);
            return NoContent();
        }
    }
}