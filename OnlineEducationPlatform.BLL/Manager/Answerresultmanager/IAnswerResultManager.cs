using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.BLL.ViewModels.AnswerResultVm;

namespace OnlineEducationPlatform.BLL.Manager.Answerresultmanager
{
    public interface IAnswerResultManager
    {
        Task<IEnumerable<AnswerResultReadVm>> GetAllAsync();

        Task<AnswerResultReadVm> GetByIdAsync(int id);

        Task AddAsync(AnswerResultAddVm answerResultAddVm);

        Task UpdateAsync(AnswerResultUpdateVm answerResultUpdateVm);

        Task DeleteAsync(int id);

        Task<bool> IdExist(int answerResultId);

        Task<bool> QuestionIdExist(int questionId);

        Task<bool> StudentIdExist(string studentId);

        Task<bool> AnswerIdExist(int answerId);

    }
}