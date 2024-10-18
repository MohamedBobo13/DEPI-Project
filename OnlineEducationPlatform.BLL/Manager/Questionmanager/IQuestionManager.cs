using OnlineEducationPlatform.BLL.Dto.QuestionDto;
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

        Task UpdateExamAsync(QuestionExamUpdateDto questionExamUpdateDto);

        Task UpdateQuizAsync(QuestionQuizUpdateDto questionQuizUpdateDto);

        Task DeleteAsync(int id);

        Task<bool> IdForExam(int questionId);

        Task<bool> IdForQuiz(int questionId);

        Task<bool> QuizIdExist(int quizId);

        Task<bool> ExamIdExist(int examId);
    }
}