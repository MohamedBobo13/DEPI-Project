using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories.QuizRepo
{
    public interface IQuizRepo
    {
        IEnumerable<Quiz> GetAll();
        Quiz GetById(int id);
        void Delete(Quiz quiz);
        void Update(Quiz quiz);
        void Add(Quiz quiz);
        void SaveChange();
    }
}
