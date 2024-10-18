using OnlineEducationPlatform.BLL.Dto.TestDto;

namespace OnlineEducationPlatform.BLL.Services.ExamService
{
    public interface IExamService
    {
        IEnumerable<ExamReadDto> GetAll();
        ExamReadDto GetById(int id);
        void Add(ExamAddDto examAddDto);
        void Update(ExamUpdateDto examUpdateDto);
        void Delete(int id);
        void SaveChanges();
    }
}
