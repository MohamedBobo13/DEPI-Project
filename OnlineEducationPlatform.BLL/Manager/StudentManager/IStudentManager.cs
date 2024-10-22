using OnlineEducationPlatform.BLL.handleresponse;
using OnlineEducationPlatform.BLL.ViewModels.StudentVm;

namespace OnlineEducationPlatform.BLL.Manager.StudentManager
{
    public interface IStudentManager
    {
        Task<ServiceResponse<List<StudentReadVm>>> GetAllStudentsAsync();

        Task<ServiceResponse<StudentReadVm>> Getstudentbyid(string studentid);
        Task<ServiceResponse<bool>> softdeleteStudent(string studentId);
    }
}
