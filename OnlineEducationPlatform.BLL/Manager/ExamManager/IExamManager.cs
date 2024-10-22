using OnlineEducationPlatform.BLL.ViewModels.ExamVm;


namespace OnlineEducationPlatform.BLL.Manager.ExamManager
{
    public interface IExamManager
    {
        Task<List<ExamReadVm>> GetAllAsync();
        Task<ExamReadVm> GetByIdAsync(int id);
        Task<ExamAddVm> AddAsync(ExamAddVm examAddDto);
        Task <ExamUpdateVm> Update(ExamUpdateVm examUpdateDto);
        Task DeleteAsync(int id);
    }
}
