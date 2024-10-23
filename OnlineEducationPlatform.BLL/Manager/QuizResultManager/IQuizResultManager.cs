using OnlineEducationPlatform.BLL.handleresponse;
using OnlineEducationPlatform.BLL.ViewModels.QuizResultsVm;
using OnlineEducationPlatform.DAL.Data.Models;


namespace OnlineEducationPlatform.BLL.Manager.QuizResultManager
{
    public interface IQuizResultManager
    {
        Task<ServiceResponse<List<QuizResultManager>>> GetAllQuizResults();

        Task<ServiceResponse<QuizResult>> GetQuizResultAsync(string studentid, int quizid);
        Task<ServiceResponse<bool>> softdeletequizresult(string studentId, int quizid);
        Task<ServiceResponse<bool>> updatequizresultbyid(UpdateQuizzResultVm quizresultreaddto);
        Task<ServiceResponse<List<quizresultwithoutidvm>>> GetAllSoftDeletedQuizresultsAsync();

        Task<ServiceResponse<bool>> HardDeleteEQuizresulttByStudentAndquizsync(string studentId, int quizid);
       Task<ServiceResponse<quizresultwithoutidvm>> CreateQuizresultAsync(quizresultwithoutidvm quizresultwithoutiddto);

       Task<ServiceResponse<List<quizresultreadvm>>> GetStudentresultssByStudentIdAsync(string studentId);
        Task<ServiceResponse<List<quizresultreadvm>>> GetstudentresultsByQuizIdAsync(int QuizId);
        



    }
}
