using OnlineEducationPlatform.BLL.ViewModels.CourseVm;


namespace OnlineEducationPlatform.BLL.Manager
{
    public interface ICourseManager
    {
        Task AddAsync(CourseAddVm courseAddVm);
        Task<IEnumerable<CourseReadVm>> GetAllAsync();
        Task<CourseReadVm> GetByIdAsync(int id);
        Task<CourseUpdateVm> UpdateAsync(CourseUpdateVm courseUpdateVm);
        Task<bool> DeleteAsync(int id);
        
    }
}
