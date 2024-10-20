using OnlineEducationPlatform.BLL.Dtos;

namespace OnlineEducationPlatform.BLL.Manager.Answermanager
{
    public interface IAnswerManager
    {
        Task<IEnumerable<AnswerReadVm>> GetAllAsync();

        Task<AnswerReadVm> GetByIdAsync(int id);

        Task AddAsync(AnswerAddVm answerAddVm);

        Task UpdateAsync(AnswerUpdateVm answerUpdateVm);

        Task DeleteAsync(int id);

        Task<bool> IdExist(int answerId);

        Task<bool> QuestionIdExist(int questionId);
    }
}