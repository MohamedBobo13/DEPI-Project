using OnlineEducationPlatform.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager.Answerresultmanager
{
    public interface IAnswerResultManager
    {
        IEnumerable<AnswerResultReadDto> GetAll();
        AnswerResultReadDto GetById(int id);
        void Add(AnswerResultAddDto answerResultAddDto);
        void Update(AnswerResultUpdateDto answerResultUpdateDto);
        void Delete(int id);
        void SaveChange();
    }
}
