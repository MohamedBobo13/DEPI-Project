using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories.ExamRepo
{
    public class ExamRepo : IExamRepo
    {
        private readonly EducationPlatformContext _context;

        public ExamRepo(EducationPlatformContext context)
        {
            _context = context;
        }

        public async Task<List<Exam>> GetAll()
        {
            return await _context.Exam.AsNoTracking().ToListAsync();
        }
    

        public async Task<Exam> GetById(int id)
        {
            return await _context.Exam.FirstOrDefaultAsync(amr => amr.Id == id);
        }
        public async Task Add(Exam exam)
        {
            await _context.Exam.AddAsync(exam);
        }

        public async Task<bool> Delete(int id)
        {
            var quiz = await _context.Exam
                                            .FirstOrDefaultAsync(e=> e.Id == id);
            if (quiz != null)
            {
                quiz.IsDeleted = true;
                await _context.SaveChangesAsync();
                return true;

            }
            return false;
        }


        public async Task SaveChange()
        {
             await _context.SaveChangesAsync();
        }

        public async Task Update(Exam exam)
        {
            _context.Exam.Update(exam);
            await _context.SaveChangesAsync();
        }
    }
}
