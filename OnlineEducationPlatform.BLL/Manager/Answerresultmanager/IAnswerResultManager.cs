using OnlineEducationPlatform.BLL.Dtos;

namespace OnlineEducationPlatform.BLL.Manager.Answerresultmanager
{
    public interface IAnswerResultManager
    {
        Task<IEnumerable<AnswerResultReadDto>> GetAllAsync();

        Task<AnswerResultReadDto> GetByIdAsync(int id);

        Task AddAsync(AnswerResultAddDto answerResultAddDto);

        Task UpdateAsync(AnswerResultUpdateDto answerResultUpdateDto);

        Task DeleteAsync(int id);

        Task<bool> QuestionIdExist(int questionId);
        
        Task<bool> AnswerIdExist(int answerId);

    }
}