using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repo.QuizRepo
{
    public interface IQuizResultRepo
    {
        Task<bool> quizresultExistsAsync(string studentId, int quizid);

        Task<bool> quizExistsAsync(int quizId);
        Task<QuizResult> GetQuizResultForStudentAsync(string studentId, int quizId);
        Task<bool> StudentExistsAsync(string studentId);
    }
}
