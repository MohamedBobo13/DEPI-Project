using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repo.QuestionRepo
{
    public interface IQuestionRepo
    {
        IEnumerable<Question> GetAll();
        IEnumerable<Question> GetAllExam();
        IEnumerable<Question> GetAllQuiz();
        Question GetById(int id);
        void Delete(Question question);
        void Update(Question question);
        void Add(Question question);
        void SaveChange();
        bool  ExamExists(int? examId);
        bool QuizExists(int? QuizId);

    }
}
