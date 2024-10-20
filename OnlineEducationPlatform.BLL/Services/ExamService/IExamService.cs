using OnlineEducationPlatform.BLL.Dto.TestDto;

namespace OnlineEducationPlatform.BLL.Services.ExamService
{
    public interface IExamService
    {
        Task<List<ExamReadDto>> GetAllAsync();
        Task<ExamReadDto> GetByIdAsync(int id);
        Task AddAsync(ExamAddDto examAddDto);
        Task UpdateAsync(ExamUpdateDto examUpdateDto);
        Task DeleteAsync(int id);
    }
}
