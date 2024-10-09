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
            var lecModel = _context.Lecture.Find(id);
            if (lecModel != null)
            {
                return lecModel;
            }
            return null;
        }
        public void Add(Lecture lecture)
        {
            _context.Add(lecture);
            SaveChange();
        }

        public void Delete(int id)
        {
            var lecModel = _context.Lecture.Find(id);
            if (lecModel != null)
            {
                _context.Lecture.Remove(lecModel);
                SaveChange();
            }
        }
        public void Update(Lecture lecture)
        {
            SaveChange();
        }
        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
