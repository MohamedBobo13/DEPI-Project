using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories.CourseRepo
{
    public class CourseRepo : ICourseRepo
    {
        private readonly EducationPlatformContext _context;

        public CourseRepo(EducationPlatformContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Course.AsNoTracking().ToList();
        }

        public Course GetById(int id)
        {
            return _context.Course.Find(id);
        }
        public void Add(Course course)
        {
            _context.Add(course);
        }

        public void Delete(Course course)
        {
            _context.Remove(course);
        }
        public void Update(Course course)
        {

        }
        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
