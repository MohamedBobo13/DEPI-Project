using AutoMapper;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager
{
    public class AnswerManager : IAnswerManager
    {
        private readonly IAnswerRepo _answerRepo;
        private readonly IMapper _mapper;

        public AnswerManager(IAnswerRepo answerRepo,IMapper mapper)
        {
            _answerRepo = answerRepo;
            _mapper = mapper;
        }
        public IEnumerable<AnswerReadDto> GetAll()
        {
            return _mapper.Map<List<AnswerReadDto>>(_answerRepo.GetAll());
        }
        public AnswerReadDto GetById(int id)
        {
            return _mapper.Map<AnswerReadDto>(_answerRepo.GetById(id));
        }
        public void Add(AnswerAddDto answerAddDto)
        {
            _answerRepo.Add(_mapper.Map<Answer>(answerAddDto));
            _answerRepo.SaveChange();
        }
        public void Update(AnswerUpdateDto answerUpdateDto)
        {
            _answerRepo.Update(_mapper.Map(answerUpdateDto, _answerRepo.GetById(answerUpdateDto.Id)));
            _answerRepo.SaveChange();
        }

        public void Delete(int id)
        {
            var AnswerModel = _answerRepo.GetById(id);
            if (AnswerModel != null)
            {
                _answerRepo.Delete(AnswerModel);
                _answerRepo.SaveChange();
            }
        }

        public void SaveChange()
        {
            _answerRepo.SaveChange();
        }
    }
}
