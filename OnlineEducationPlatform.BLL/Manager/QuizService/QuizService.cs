using AutoMapper;
using OnlineEducationPlatform.BLL.Dto.TestDto;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repositories.QuizRepo;

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
        public async Task<List<QuizReadDto>> GetAllAsync()
        {
           //Auto-Mapping
           return _mapper.Map<List<QuizReadDto>>(_quizRepo.GetAll());
        }

        public async Task<QuizReadDto> GetByIdAsync(int id)
        {
            var quiz = await _quizRepo.GetById(id);
            if (quiz is null)
            {
                return null;
            }
            //Auto-Mapping
            return _mapper.Map<QuizReadDto>(quiz);
        }

        public async Task AddAsync(QuizAddDto quizAddDto)
        {
            await _quizRepo.Add(_mapper.Map<Quiz>(quizAddDto));
        }


        public async Task UpdateAsync(QuizUpdateDto quizUpdateDto)
        {
            var quiz = await _quizRepo.GetById(quizUpdateDto.Id);
            if (quiz is null)
            {
                return;
            }
            //Auto-Mapping
            _quizRepo.Update(_mapper.Map(quizUpdateDto, quiz));
        }

        public async Task DeleteAsync(int id)
        {
            var quiz = await _quizRepo.GetById(id);
            if (quiz is null)
            {
                return;
            }
            await _quizRepo.Delete(quiz.Id);
        }
    }
}
