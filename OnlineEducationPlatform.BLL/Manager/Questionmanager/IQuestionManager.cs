using OnlineEducationPlatform.BLL.Dtos;

namespace OnlineEducationPlatform.BLL.Manager.Questionmanager
{
    public interface IQuestionManager
    {
        Task<IEnumerable<QuestionReadDto>> GetAllAsync();

        Task<IEnumerable<QuestionExamReadDto>> GetAllExamAsync();

        Task<IEnumerable<QuestionQuizReadDto>> GetAllQuizAsync();

        Task<QuestionReadDto> GetByIdAsync(int id);
        Task AddQuizAsync(QuestionQuizAddDto questionQuizAddDto);

        Task AddExamAsync(QuestionExamAddDto questionExamAddDto);

        Task UpdateAsync(QuestionUpdateDto questionUpdateDto);
        Task DeleteAsync(int id);
    }
}