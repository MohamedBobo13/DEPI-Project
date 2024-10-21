using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DBHelper;
using OnlineEducationPlatform.DAL.Data.Models;

namespace OnlineEducationPlatform.DAL.Repo.ExamRepo
{
	public  class ExamRepo : IExamRepo
    {
        private readonly EducationPlatformContext _context;

        public ExamRepo(EducationPlatformContext educationPlatformContext)
        {
            _context = educationPlatformContext;
        }
        public async Task Add(Exam exam)
        {
            await _context.Exam.AddAsync(exam);

        }

        public async Task<bool> Delete(int id)
        {
            var exam = await _context.Exam
                                        .FirstOrDefaultAsync(e => e.Id == id);
            if (exam != null)
            {
                exam.IsDeleted = true;
                _context.Update(exam);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Exam>> GetAll()
        {
            return await _context.Exam.AsNoTracking().ToListAsync();

        }

        public async Task<Exam> GetById(int id)
        {
            return await _context.Exam
                                         .FirstOrDefaultAsync(a => a.Id == id);
        }
       
        public async Task Updateasync(Exam exam)
        {
            _context.Exam.Update(exam);
       //     await _context.SaveChangesAsync();
            //   await _context.SaveChangesAsync();
            //    await SaveChange();
        }
        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> examExistsAsyncbyid(int id)
        {
            return await _context.Exam
                .AnyAsync(e => e.Id == id);
        }

    }
}
