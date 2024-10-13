using OnlineEducationPlatform.BLL.Dto.TestResultDto;

namespace OnlineEducationPlatform.BLL.Services.ExamResultService
{
    public interface IExamResultService
    {
        IEnumerable<ExamResultReadDto> GetAll();
        ExamResultReadDto GetById(int id);
        void Delete(int id);
        void SaveChanges();
    }
}
