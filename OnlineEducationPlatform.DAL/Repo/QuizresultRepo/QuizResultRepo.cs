using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repo.QuizRepo
{
    public class QuizResultRepo : IQuizResultRepo
    {
        private readonly EducationPlatformContext _context;

        public QuizResultRepo(EducationPlatformContext Context)
        {
            _context = Context;
        }
        public async Task<QuizResult> GetQuizResultForStudentAsync(string studentId, int quizId)
        {

            return await _context.QuizResult
                .FirstOrDefaultAsync(qr => qr.StudentId == studentId && qr.QuizId == quizId);


        }
        public async Task<bool> quizExistsAsync(int QuizId)
        {
            return await _context.Quiz.AnyAsync(c => c.Id == QuizId);
        }
        public async Task<bool> quizresultExistsAsync(string studentId, int quizid)
        {
            return await _context.QuizResult
                .AnyAsync(e => e.StudentId == studentId && e.QuizId == quizid);
        }
        public async Task<bool> StudentExistsAsync(string studentId)
        {
            return await _context.User.AnyAsync(U => U.Id == studentId && U.UserType == TypeUser.Student);
        }


    }
}
