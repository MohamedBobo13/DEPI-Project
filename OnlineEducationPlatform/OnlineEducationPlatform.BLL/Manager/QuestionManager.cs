using AutoMapper;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repo.QuestionRepo;
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
        public IEnumerable<QuestionQuizReadDto> GetAllQuiz()
        {
            return _mapper.Map<List<QuestionQuizReadDto>>(_questionRepo.GetAllQuiz());
        }
        public IEnumerable<QuestionExamReadDto> GetAllExam()
        {
            return _mapper.Map<List<QuestionExamReadDto>>(_questionRepo.GetAllExam());
        }
        public QuestionReadDto GetById(int id)
        {
            return _mapper.Map<QuestionReadDto>(_questionRepo.GetById(id));
        }
        public void AddQuiz(QuestionQuizAddDto questionQuizAddDto)
        {
            _questionRepo.Add(_mapper.Map<Question>(questionQuizAddDto));
            _questionRepo.SaveChange();
        }
        public void AddExam(QuestionExamAddDto questionExamAddDto)
        {
            _questionRepo.Add(_mapper.Map<Question>(questionExamAddDto));
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
            if (QuestionModel != null)
            {
                _questionRepo.Delete(QuestionModel);
                _questionRepo.SaveChange();
            }
        }
        public void SaveChange()
        {
            _questionRepo.SaveChange();
        }

    }
}
