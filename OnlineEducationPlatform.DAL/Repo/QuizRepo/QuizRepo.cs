using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Data.Models;

namespace OnlineEducationPlatform.DAL.Repositories.QuizRepo
{
    public class QuizRepo : IQuizRepo
    {
        private readonly EducationPlatformContext _context;

        public QuizRepo(EducationPlatformContext context)
        {
            _context = context;
        }

        public async Task<List<Quiz>> GetAll()
        {
            return await _context.Quiz.AsNoTracking().ToListAsync();
        }


        public async Task<Quiz> GetById(int id)
        {
            return await _context.Quiz
                                    .FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task Add(Quiz quiz)
        {
            await _context.Quiz.AddAsync(quiz);
            await SaveChange();
        }

        public async Task Delete(int id)
        {
            var quiz = await _context.Quiz
                                       .FirstOrDefaultAsync(e => e.Id == id);
            if (quiz != null)
            {
                quiz.IsDeleted = true;
                _context.Update(quiz);
                await SaveChange();
            }
        }
        public async Task Update(Quiz quiz)
        {
            _context.Quiz.Update(quiz);
            await SaveChange();
        }
        public async Task SaveChange()
        {
             await _context.SaveChangesAsync();
        }

    }
}
