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
    public class LectureRepo : ILectureRepo
    {
        private readonly EducationPlatformContext _context;

        public LectureRepo(EducationPlatformContext context)
        {
            _context = context;
        }

        public IEnumerable<Lecture> GetAll()
        {
            return _context.Lecture.AsNoTracking().ToList();
        }

        public Lecture GetById(int id)
        {
            return _context.Lecture.Find(id);
        }
        public void Add(Lecture lecture)
        {
            _context.Add(lecture);
        }

        public void Delete(Lecture lecture)
        {
            _context.Remove(lecture);
        }
        public void Update(Lecture lecture)
        {

        }
        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
