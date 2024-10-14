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
        IEnumerable<QuestionExamReadDto> GetAllExam();
        IEnumerable<QuestionQuizReadDto> GetAllQuiz();
        QuestionReadDto GetById(int id);
        bool AddQuiz(QuestionQuizAddDto questionQuizAddDto);
        bool Addexam(QuestionExamAddDto questionExamAddDto);

        void Update(QuestionUpdateDto questionUpdateDto);
        void Delete(int id);
        void SaveChange();
    }
}
