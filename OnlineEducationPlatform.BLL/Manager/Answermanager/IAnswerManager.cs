using OnlineEducationPlatform.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager.Answermanager
{
    public interface IAnswerManager
    {
        IEnumerable<AnswerReadDto> GetAll();
        AnswerReadDto GetById(int id);
        void Add(AnswerAddDto answerAddDto);
        void Update(AnswerUpdateDto answerUpdateDto);
        void Delete(int id);
        void SaveChange();
    }
}
