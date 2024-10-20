using OnlineEducationPlatform.BLL.Dto.QuestionDto;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.DAL.Data.Models;

namespace OnlineEducationPlatform.BLL.Manager.Questionmanager
{
    public interface IQuestionManager
    {
        Task<IEnumerable<QuestionReadVm>> GetAllAsync();

        Task<IEnumerable<QuestionCourseExamReadVm>> GetCourseExamAsync(int courseId);

        Task<IEnumerable<QuestionCourseQuizReadVm>> GetCourseQuizAsync(int courseId);

        Task<QuestionReadVm> GetByIdAsync(int id);

        Task AddQuizAsync(QuestionQuizAddVm questionQuizAddDto);

        Task AddExamAsync(QuestionExamAddVm questionExamAddDto);

        Task UpdateExamAsync(QuestionExamUpdateVm questionExamUpdateDto);

        Task UpdateQuizAsync(QuestionQuizUpdateVm questionQuizUpdateDto);

        Task DeleteAsync(int id);

        Task<bool> IdForExam(int questionId);

        Task<bool> IdForQuiz(int questionId);

        Task<bool> QuizIdExist(int quizId);

        Task<bool> ExamIdExist(int examId);

        Task<bool> CourseIdExist(int courseId);
    }
}