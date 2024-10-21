using OnlineEducationPlatform.BLL.QuizVm;
using OnlineEducationPlatform.BLL.ViewModels.QuizVm;

namespace OnlineEducationPlatform.BLL.Manager.QuizManager
{
    public interface IQuizManager
    {
        Task<List<QuizReadVm>> GetAllAsync();
        Task<QuizReadVm> GetByIdAsync(int id);
        Task<QuizAddVm> AddAsync(QuizAddVm quizAddDto);
        Task <QuizUpdateVm>UpdateAsync(QuizUpdateVm quizUpdateDto);
        Task DeleteAsync(int id);
    }
}
