using AutoMapper;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repo.AnswerResultRepo;
using OnlineEducationPlatform.DAL.Repositories;

namespace OnlineEducationPlatform.BLL.Manager.Answerresultmanager
{
    public class AnswerResultManager : IAnswerResultManager
    {
        private readonly IAnswerResultRepo _answerResultRepo;
        private readonly IMapper _mapper;

        public AnswerResultManager(IAnswerResultRepo answerResultRepo, IMapper mapper)
        {
            _answerResultRepo = answerResultRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AnswerResultReadVm>> GetAllAsync()
        {
            var answerResults = await _answerResultRepo.GetAllAsync();
            return _mapper.Map<List<AnswerResultReadVm>>(answerResults);
        }

        public async Task<AnswerResultReadVm> GetByIdAsync(int id)
        {
            var answerResult = await _answerResultRepo.GetByIdAsync(id);

            if (answerResult == null)
                return null;

            return _mapper.Map<AnswerResultReadVm>(answerResult);
        }
        public async Task AddAsync(AnswerResultAddVm answerResultAddDto)
        {
            await _answerResultRepo.AddAsync(_mapper.Map<AnswerResult>(answerResultAddDto));
        }
        public async Task UpdateAsync(AnswerResultUpdateVm answerResultUpdateDto)
        {
            var existingAnswerResult = await _answerResultRepo.GetByIdAsync(answerResultUpdateDto.Id);
            if (existingAnswerResult == null)
            {
                return;
            }
            _answerResultRepo.UpdateAsync(_mapper.Map(answerResultUpdateDto, existingAnswerResult));
        }
        public async Task DeleteAsync(int id)
        {
            var AnswerModelResult = await _answerResultRepo.GetByIdAsync(id);
            if (AnswerModelResult != null)
            {
                await _answerResultRepo.DeleteAsync(AnswerModelResult);
            }
        }

        public async Task<bool> IdExist(int answerResultId)
        {
            bool idExist = await _answerResultRepo.IdExist(answerResultId);
            if (idExist)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> QuestionIdExist(int questionId)
        {
            bool questionExist = await _answerResultRepo.QuestionIdExist(questionId);
            if (questionExist)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> StudentIdExist(string studentId)
        {
            bool studentExist = await _answerResultRepo.StudentIdExist(studentId);
            if (studentExist)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> AnswerIdExist(int answerId)
        {
            bool answerExist = await _answerResultRepo.AnsweerIdExist(answerId);
            if (answerExist)
            {
                return true;
            }
            return false;
        }
    }
}