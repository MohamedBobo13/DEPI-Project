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
    public class StudentProgressRepo : IStudentProgressRepo
    {
        private readonly EducationPlatformContext _context;

        public StudentProgressRepo(EducationPlatformContext context)
        {
            _context = context;
        }

        public IEnumerable<StudentProgress> GetAll()
        {
            return _context.StudentProgress.AsNoTracking().ToList();
        }

        public StudentProgress GetById(int id)
        {
            return _context.StudentProgress.Find(id);
        }
        public void Add(StudentProgress studentProgress)
        {
            _context.Add(studentProgress);
        }

        public void Delete(StudentProgress studentProgress)
        {
            _context.Remove(studentProgress);
        }
        public void Update(StudentProgress studentProgress)
        {

        }
        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
