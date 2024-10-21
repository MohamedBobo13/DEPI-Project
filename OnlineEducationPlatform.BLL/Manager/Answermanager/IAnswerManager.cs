using OnlineEducationPlatform.BLL.Dtos;

namespace OnlineEducationPlatform.BLL.Manager.Answermanager
{
    public interface IAnswerManager
    {
        List<AnswerReadVm> GetAll();

        AnswerReadVm GetById(int id);

        void Add(AnswerAddVm answerAddVm);

        void Update(AnswerUpdateVm answerUpdateVm);

        void Delete(int id);

    }
}