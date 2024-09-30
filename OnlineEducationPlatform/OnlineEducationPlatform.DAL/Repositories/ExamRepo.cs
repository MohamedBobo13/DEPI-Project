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
    public class ExamRepo : IExamRepo
    {
        private readonly EducationPlatformContext _context;

        public ExamRepo(EducationPlatformContext context)
        {
            _context = context;
        }

        public IEnumerable<Exam> GetAll()
        {
            return _context.Exam.AsNoTracking().ToList();
        }

        public Exam GetById(int id)
        {
            return _context.Exam.Find(id);
        }
        public void Add(Exam exam)
        {
            _context.Add(exam);
        }

        public void Delete(Exam exam)
        {
            _context.Remove(exam);
        }
        public void Update(Exam exam)
        {

        }
        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
