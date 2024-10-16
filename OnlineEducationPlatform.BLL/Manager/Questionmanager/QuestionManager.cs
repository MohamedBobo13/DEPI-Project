using AutoMapper;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repo.QuestionRepo;
using OnlineEducationPlatform.DAL.Repositories;

namespace OnlineEducationPlatform.BLL.Manager.Questionmanager
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
        public async Task<IEnumerable<QuestionReadDto>> GetAllAsync()
        {
            var questions = await _questionRepo.GetAllAsync();
            return _mapper.Map<List<QuestionReadDto>>(questions);
        }

        public async Task<IEnumerable<QuestionExamReadDto>> GetAllExamAsync()
        {
            var questionsExam = await _questionRepo.GetAllExamAsync();
            return _mapper.Map<List<QuestionExamReadDto>>(questionsExam);
        }

        public async Task<IEnumerable<QuestionQuizReadDto>> GetAllQuizAsync()
        {
            var questionsQuiz = await _questionRepo.GetAllQuizAsync();
            return _mapper.Map<List<QuestionQuizReadDto>>(questionsQuiz);
        }

        public async Task<QuestionReadDto> GetByIdAsync(int id)
        {
            var question = await _questionRepo.GetByIdAsync(id);

            if (question == null)
                return null;

            return _mapper.Map<QuestionReadDto>(question);
        }
        public async Task AddExamAsync(QuestionExamAddDto questionExamAddDto)
        {
            await _questionRepo.AddAsync(_mapper.Map<Question>(questionExamAddDto));
        }

        public async Task AddQuizAsync(QuestionQuizAddDto questionQuizAddDto)
        {
            await _questionRepo.AddAsync(_mapper.Map<Question>(questionQuizAddDto));
        }
        public async Task UpdateAsync(QuestionUpdateDto questionUpdateDto)
        {
            var existingQuestion = await _questionRepo.GetByIdAsync(questionUpdateDto.Id);
            if (existingQuestion == null)
            {
                return;
            }
            _questionRepo.UpdateAsync(_mapper.Map(questionUpdateDto, existingQuestion));
        }
        public async Task DeleteAsync(int id)
        {
            var questionModel = await _questionRepo.GetByIdAsync(id);
            if (questionModel != null)
            {
                await _questionRepo.DeleteAsync(questionModel);
            }
        }

    }
}