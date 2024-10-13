using AutoMapper;
using OnlineEducationPlatform.BLL.Dto.TestDto;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repositories.QuizRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Services.QuizService
{
    public class QuizService : IQuizService
    {
        private readonly QuizRepo _quizRepo;
        private readonly IMapper _mapper;

        public QuizService(QuizRepo quizRepo, IMapper mapper)
        {
            _quizRepo = quizRepo;
            _mapper = mapper;
        }
        public IEnumerable<QuizReadDto> GetAll()
        {
           //Auto-Mapping
           return _mapper.Map<List<QuizReadDto>>(_quizRepo.GetAll());
        }

        public QuizReadDto GetById(int id)
        {
            //Auto-Mapping
            return _mapper.Map<QuizReadDto>(_quizRepo.GetById(id));
        }

        public void Add(QuizAddDto quizAddDto)
        {
            //Auto-Mapping
            _quizRepo.Add(_mapper.Map<Quiz>(quizAddDto));
            _quizRepo.SaveChange();
        }


        public void Update(QuizUpdateDto quizUpdateDto)
        {
            //Auto-Mapping
             var QuizModel = _quizRepo.GetById(quizUpdateDto.Id);
            _mapper.Map<QuizUpdateDto, Quiz>(quizUpdateDto, QuizModel);
        }

        public void Delete(int id)
        {
            var QuizModel = _quizRepo.GetById(id);
            _quizRepo.Delete(QuizModel);
        }

        public void SaveChanges()
        {
            _quizRepo.SaveChange();
        }
    }
}
