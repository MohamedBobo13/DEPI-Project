using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories
{
    public class ExamResultRepo : IExamResultRepo
    {
        private readonly EducationPlatformContext _context;

        public ExamResultRepo(EducationPlatformContext context)
        {
            _context = context;
        }

        public IEnumerable<ExamResult> GetAll()
        {
            return _context.ExamResult.AsNoTracking().ToList();
        }

        public ExamResult GetById(int id)
        {
            return _context.ExamResult.Find(id);
        }
        public void Add(ExamResult examResult)
        {
            _context.Add(examResult);
        }

        public void Delete(ExamResult examResult)
        {
            _context.Remove(examResult);
        }
        public void Update(ExamResult examResult)
        {

        }
        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
