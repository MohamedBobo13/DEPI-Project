using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories
{
    public interface IQuizResultRepo
    {
        IEnumerable<QuizResult> GetAll();
        QuizResult GetById(int id);
        void Delete(QuizResult quizResult);
        void Update(QuizResult quizResult);
        void Add(QuizResult quizResult);
        void SaveChange();
    }
}
