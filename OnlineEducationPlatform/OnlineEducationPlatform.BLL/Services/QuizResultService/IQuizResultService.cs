using OnlineEducationPlatform.BLL.Dto.TestResultDto;

namespace OnlineEducationPlatform.BLL.Services.QuizResultService
{
    public interface IQuizResultService
    {
        IEnumerable<QuizResultReadDto> GetAll();
        QuizResultReadDto GetById(int id);
        void Delete(int id);
        void SaveChanges();
    }
}
