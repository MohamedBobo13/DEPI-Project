using OnlineEducationPlatform.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager
{
    public interface IQuestionManager
    {
        IEnumerable<QuestionReadDto> GetAll();
        QuestionReadDto GetById(int id);
        void Add(QuestionAddDto questionAddDto);
        void Update(QuestionUpdateDto questionUpdateDto);
        void Delete(int id);
        void SaveChange();
    }
}
