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
    public class CourseRepo : ICourseRepo
    {
        private readonly EducationPlatformContext _context;

        public CourseRepo(EducationPlatformContext context)
        {
            _context = context;
        }

        public void Add(Course course)
        {
            _context.Add(course);
            SaveChanges();
        }

        public void Delete(int id)
        {
            var courseModel = _context.Course.Find(id);
            if (courseModel != null)
            {
                _context.Course.Remove(courseModel);
                SaveChanges();
            };
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Course.AsNoTracking().ToList();
        }

        public Course GetById(int id)
        {
            var courseModel = _context.Course.Find(id);
            if (courseModel != null)
            {
                return courseModel;
            }
            return null;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Course course)
        {
            SaveChanges();
        }
    }
}
