using OnlineEducationPlatform.BLL.Dtos;

namespace OnlineEducationPlatform.BLL.Manager.Answermanager
{
    public interface IAnswerManager
    {
        Task<IEnumerable<AnswerReadDto>> GetAllAsync();

        Task<AnswerReadDto> GetByIdAsync(int id);

        Task AddAsync(AnswerAddDto answerAddDto);

        Task UpdateAsync(AnswerUpdateDto answerUpdateDto);

        Task DeleteAsync(int id);

        Task<bool> QuestionIdExist(int questionId);
    }
}