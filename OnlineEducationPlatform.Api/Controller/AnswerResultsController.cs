﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.BLL.Manager;
using OnlineEducationPlatform.BLL.Manager.Answerresultmanager;
using OnlineEducationPlatform.DAL.Data.Models;

namespace OnlineEducationPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerResultsController : ControllerBase
    {
        private readonly IAnswerResultManager _answerResultManager;

        public AnswerResultsController(IAnswerResultManager answerResultManager)
        {
            _answerResultManager = answerResultManager;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _answerResultManager.GetAllAsync());
        }
        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            var answerResult = await _answerResultManager.GetByIdAsync(Id);
            if (answerResult == null)
            {
                return NotFound();
            }
            return Ok(answerResult);
        }
        [HttpPost]
        public async Task<ActionResult> Add(AnswerResultAddDto answerResultAddDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _answerResultManager.AddAsync(answerResultAddDto);
            return NoContent();
        }
        [HttpPut]
        [Route("{Id}")]
        public async Task<ActionResult> Update(int Id, AnswerResultUpdateDto answerResultUpdateDto)
        {
            if (Id != answerResultUpdateDto.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }
            await _answerResultManager.UpdateAsync(answerResultUpdateDto);
            return NoContent();
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int Id)
        {
            await _answerResultManager.DeleteAsync(Id);
            return NoContent();
        }
    }
}
