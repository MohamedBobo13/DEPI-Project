using AutoMapper;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager
{
    public class QuestionManager : IQuestionManager
    {
        private readonly IQuestionRepo _questionRepo;
        private readonly IMapper _mapper;

        public QuestionManager(IQuestionRepo questionRepo, IMapper mapper)
        {
            _questionRepo = questionRepo;
            _mapper = mapper;
        }
        public IEnumerable<QuestionReadDto> GetAll()
        {
            return _mapper.Map<List<QuestionReadDto>>(_questionRepo.GetAll());
        }
        public QuestionReadDto GetById(int id)
        {
            return _mapper.Map<QuestionReadDto>(_questionRepo.GetById(id));
        }
        public void Add(QuestionAddDto questionAddDto)
        {
            _questionRepo.Add(_mapper.Map<Question>(questionAddDto));
            _questionRepo.SaveChange();
        }
        public void Update(QuestionUpdateDto questionUpdateDto)
        {
            _questionRepo.Update(_mapper.Map(questionUpdateDto, _questionRepo.GetById(questionUpdateDto.Id)));
            _questionRepo.SaveChange();
        }

        public void Delete(int id)
        {
            var QuestionModel = _questionRepo.GetById(id);
            _questionRepo.Delete(QuestionModel);
            _questionRepo.SaveChange();
        }

        public void SaveChange()
        {
            _questionRepo.SaveChange();
        }
    }
}
