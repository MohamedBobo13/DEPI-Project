﻿using AutoMapper;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repo.AnswerRepo;
using OnlineEducationPlatform.DAL.Repositories;

namespace OnlineEducationPlatform.BLL.Manager.Answermanager
{
    public class AnswerManager : IAnswerManager
    {
        private readonly IAnswerRepo _answerRepo;
        private readonly IMapper _mapper;

        public AnswerManager(IAnswerRepo answerRepo, IMapper mapper)
        {
            _answerRepo = answerRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AnswerReadVm>> GetAllAsync()
        {
            var answers = await _answerRepo.GetAllAsync();
            return _mapper.Map<List<AnswerReadVm>>(answers);
        }
        public async Task<AnswerReadVm> GetByIdAsync(int id)
        {
            var answer = await _answerRepo.GetByIdAsnyc(id);

            if (answer == null)
                return null;

            return _mapper.Map<AnswerReadVm>(answer);
        }
        public async Task AddAsync(AnswerAddVm answerAddVm)
        {
            await _answerRepo.AddAsync(_mapper.Map<Answer>(answerAddVm));
        }
        public async Task UpdateAsync(AnswerUpdateVm answerUpdateDto)
        {
            var existingAnswer = await _answerRepo.GetByIdAsnyc(answerUpdateDto.Id);
            if (existingAnswer == null)
            {
                return;
            }
            _answerRepo.UpdateAsync(_mapper.Map(answerUpdateDto, existingAnswer));
        }
        public async Task DeleteAsync(int id)
        {
            var AnswerModel = await _answerRepo.GetByIdAsnyc(id);
            if (AnswerModel != null)
            {
                await _answerRepo.DeleteAsync(AnswerModel);
            }
        }

        public async Task<bool> IdExist(int answerId)
        {
            bool idExist = await _answerRepo.IdExist(answerId);
            if (idExist)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> QuestionIdExist(int questionId)
        {
            bool questionExist = await _answerRepo.QuestionIdExist(questionId);
            if (questionExist)
            {
                return true;
            }
            return false;
        }

        
    }
}