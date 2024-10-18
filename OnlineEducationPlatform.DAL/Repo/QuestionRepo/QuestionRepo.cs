using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repo.QuestionRepo
{
    public class QuestionRepo : IQuestionRepo
    {
        private readonly EducationPlatformContext _context;

        public QuestionRepo(EducationPlatformContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await _context.Question.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Question>> GetAllExamAsync()
        {
            return await _context.Question.Where(e => e.ExamId != null).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Question>> GetAllQuizAsync()
        {
            return await _context.Question.Where(e => e.QuizId != null).AsNoTracking().ToListAsync();
        }

        public async Task<Question> GetByIdAsync(int id)
        {
            return await _context.Question.FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task AddAsync(Question question)
        {
            await _context.AddAsync(question);
            await SaveChangeAsync();
        }
        public async Task UpdateAsync(Question question)
        {
            _context.Update(question);
            await SaveChangeAsync();
        }
        public async Task DeleteAsync(Question question)
        {
            question.IsDeleted = true;
            _context.Update(question);
            await SaveChangeAsync();
        }
        public async Task<bool> QuizIdExist(int quizId)
        {
            var quizExist = await _context.Quiz.AnyAsync(q => q.Id == quizId);
            if (quizExist)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ExamIdExist(int examId)
        {
            var examExist = await _context.Exam.AnyAsync(e => e.Id == examId);
            if (examExist)
            {
                return true;
            }
            return false;
        }
        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}