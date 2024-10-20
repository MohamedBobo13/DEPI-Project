using OnlineEducationPlatform.BLL.Dto.ExamResultDto;
using OnlineEducationPlatform.BLL.Dto.Quizresultsdto;
using OnlineEducationPlatform.BLL.handleresponse;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager.ExamResultmanager
{
    public interface IExamResultmanager
    {
        Task<ServiceResponse<List<Examresultreadvm>>> GetAllExamResults();

        Task<ServiceResponse<ExamResult>> GetExamResultAsync(string studentid, int examid);
        Task<ServiceResponse<bool>> softdeleteexamresult(string studentId, int examid);
        Task<ServiceResponse<bool>> updateexamresultbyid(updateexamresultVm examresultreaddto);
        Task<ServiceResponse<List<Examresultwithoutidvm>>> GetAllSoftDeletedexamresultsAsync();

        Task<ServiceResponse<bool>> HardDeleteExamresulttByStudentAndquizsync(string studentId, int examid);
        Task<ServiceResponse<Examresultwithoutidvm>> CreateexamresultAsync(Examresultwithoutidvm examresultwithoutiddto);

        Task<ServiceResponse<List<Examresultreadvm>>> GetStudentresultssByStudentIdAsync(string studentId);
        Task<ServiceResponse<List<Examresultreadvm>>> GetstudentresultsByExamIdAsync(int examid);

    }
}
