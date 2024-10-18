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
        Task<List<Quiz>> GetAll();
        Task<Quiz> GetById(int id);
        Task Add(Quiz quiz);
        Task Update(Quiz quiz);
        Task Delete(int id);
        Task SaveChange();
    }
}
