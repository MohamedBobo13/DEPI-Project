using OnlineEducationPlatform.BLL.handleresponse;
using OnlineEducationPlatform.BLL.ViewModels.ExamResultVm;
using OnlineEducationPlatform.DAL.Data.Models;


namespace OnlineEducationPlatform.BLL.Manager.ExamResultmanager
{
    public interface IExamResultmanager
    {
        Task<ServiceResponse<List<Examresultreadvm>>> GetAllExamResults();

        Task<ServiceResponse<ExamResult>> GetExamResultAsync(string studentid, int examid);
        Task<ServiceResponse<bool>> softdeleteexamresult(string studentId, int examid);
        Task<ServiceResponse<bool>> updateexamresultbyid(UpdateExamResultVm examresultreaddto);
        Task<ServiceResponse<List<Examresultwithoutidvm>>> GetAllSoftDeletedexamresultsAsync();

        Task<ServiceResponse<bool>> HardDeleteExamresulttByStudentAndquizsync(string studentId, int examid);
        Task<ServiceResponse<Examresultwithoutidvm>> CreateexamresultAsync(Examresultwithoutidvm examresultwithoutiddto);

        Task<ServiceResponse<List<Examresultreadvm>>> GetStudentresultssByStudentIdAsync(string studentId);
        Task<ServiceResponse<List<Examresultreadvm>>> GetstudentresultsByExamIdAsync(int examid);

    }
}
