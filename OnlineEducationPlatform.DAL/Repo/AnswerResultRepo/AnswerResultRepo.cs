using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repo.AnswerResultRepo
{
    public class AnswerResultRepo : IAnswerResultRepo
    {
        private readonly EducationPlatformContext _context;

        public AnswerResultRepo(EducationPlatformContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<AnswerResult>> GetAllAsync()
        {
            return await _context.AnswerResult.AsNoTracking().ToListAsync();
        }
        public async Task<AnswerResult> GetByIdAsync(int id)
        {
            return await _context.AnswerResult.FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task AddAsync(AnswerResult answerResult)
        {
            await _context.AddAsync(answerResult);
            await SaveChangeAsync();
        }
        public async Task UpdateAsync(AnswerResult answerResult)
        {
            _context.Update(answerResult);
            await SaveChangeAsync();
        }
        public async Task DeleteAsync(AnswerResult answerResult)
        {
            answerResult.IsDeleted = true;
            _context.Update(answerResult);
            await SaveChangeAsync();
        }
        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}