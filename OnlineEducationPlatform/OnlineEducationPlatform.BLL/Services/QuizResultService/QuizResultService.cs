using AutoMapper;
using OnlineEducationPlatform.BLL.Dto.TestResultDto;
using OnlineEducationPlatform.DAL.Repositories.QuizResultRepo;

namespace OnlineEducationPlatform.BLL.Services.QuizResultService
{
    public class QuizResultService : IQuizResultService
    {
        private readonly QuizResultRepo _quizResultRepo;
        private readonly IMapper _mapper;

        public QuizResultService(QuizResultRepo quizResultRepo, IMapper mapper)
        {
            _quizResultRepo = quizResultRepo;
            _mapper = mapper;
        }
        public IEnumerable<QuizResultReadDto> GetAll()
        {
            return _mapper.Map<List<QuizResultReadDto>>(_quizResultRepo.GetAll());
        }

        public QuizResultReadDto GetById(int id)
        {
            return _mapper.Map<QuizResultReadDto>(_quizResultRepo.GetById(id));
        }
        public void Delete(int id)
        {
            var QuizResultModel = _quizResultRepo.GetById(id);
            _quizResultRepo.Delete(QuizResultModel);
        }
        public void SaveChanges()
        {
            _quizResultRepo.SaveChange();
        }

    }
}
