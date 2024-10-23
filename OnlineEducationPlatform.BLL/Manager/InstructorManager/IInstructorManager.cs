using OnlineEducationPlatform.BLL.handleresponse;
using OnlineEducationPlatform.BLL.ViewModels.InstructorVm;

namespace OnlineEducationPlatform.BLL.Manager.InstructorManager
{
    public interface IInstructorManager
    {
        Task<ServiceResponse<List<InstructorReadVm>>> GetAllInstructorsAsync();
        Task<ServiceResponse<InstructorReadVm>> GetInstructorbyid(string InstructorId);
        Task<ServiceResponse<bool>> softdeleteInstructor(string InstructorId);
    }
}
