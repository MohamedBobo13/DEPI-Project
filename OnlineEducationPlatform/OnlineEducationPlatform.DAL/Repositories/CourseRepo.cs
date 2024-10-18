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

        #region old version
        //public void Add(Course course)
        //{
        //    _context.Add(course);
        //    SaveChanges();
        //}

        //public void Delete(int id)
        //{
        //    var courseModel = _context.Course.Find(id);
        //    if (courseModel != null)
        //    {
        //        courseModel.IsDeleted = true;
        //        SaveChanges();
        //    };
        //}

        //public IEnumerable<Course> GetAll()
        //{
        //    var courses= _context.Course.AsNoTracking().Where(C=>C.IsDeleted==false).ToList();
        //    if (courses == null)
        //    {
        //        return null;
        //    }
        //    return courses;
        //}

        //public Course GetById(int id)
        //{
        //    var courseModel = _context.Course.Find(id);
        //    if (courseModel != null)
        //    {
        //        return courseModel;
        //    }
        //    return null;
        //}

        //public void SaveChanges()
        //{
        //    _context.SaveChanges();
        //}

        //public void Update(Course course)
        //{
        //    SaveChanges();
        //}


        //public async Task<Course> GetById(int id)
        //{
        //    var courseModel = await _context.Course.FindAsync(id);
        //    // No need for an explicit null check; if not found, FindAsync will return null.
        //    return courseModel;
        //} 
        #endregion

        public async Task AddAsync(Course course)
        {
            await _context.Course.AddAsync(course);
            SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            var courses= await _context.Course.AsNoTracking().Where(c=>c.IsDeleted==false).ToListAsync();
            if (courses != null)
            {
                return courses;
            }
            return null;
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            
            return await _context.Course.Where(c=>c.IsDeleted==false)
                .FirstOrDefaultAsync(c=>c.Id==id);
        }

        public async Task UpdateAsync(Course course)
        {
            await SaveChangesAsync();

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var course= await _context.Course.FindAsync(id);
            if (course != null)
            {
                course.IsDeleted = true;
                await SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
