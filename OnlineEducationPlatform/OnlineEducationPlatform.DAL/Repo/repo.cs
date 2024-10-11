using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repo
{
    public class repo:Irepo
    {
        private readonly EducationPlatformContext _context;

        public repo(EducationPlatformContext Context)
        {
            _context = Context;
        }
        

       
        // Get all enrollments
     

        // Get enrollment by ID
     

        // Get enrollments by student ID
        public async Task<IEnumerable<Enrollment>> GetByStudentIdAsync(string studentId)
        {
            return await _context.Enrollment
                .Where(e => e.StudentId == studentId)
                
                .ToListAsync();
        }

        // Get enrollments by course ID
        public async Task<IEnumerable<Enrollment>> GetByCourseIdAsync(int courseId)
        {
            return await _context.Enrollment
                .Where(e => e.CourseId == courseId)
                
                .ToListAsync();
        }

        // Add new enrollment
        public async Task AddAsync(Enrollment enrollment)
        {
            await _context.Enrollment.AddAsync(enrollment);
           // await _context.SaveChangesAsync();
        }

        // Update enrollment
      

        // Delete enrollment
     

        public async Task<bool> StudentExistsAsync(string studentId)
        {
            return await _context.User.AnyAsync(U=>U.Id == studentId && U.Type==UserType.Student);
        }

        public async Task<bool> CourseExistsAsync(int CourseId)
        {
            return await _context.Course.AnyAsync(c=>c.Id==CourseId);
        }
        public async Task<bool> EnrollmentExistsAsync(string studentId, int courseId)
        {
            return await _context.Enrollment
                .AnyAsync(e => e.StudentId == studentId && e.CourseId == courseId);
        }
      
        public async Task<bool> CompleteAsync()
        {
             return await _context.SaveChangesAsync()>0;
        }

        public async Task<bool> RemoveAsync(string StudentId,int CourseId)
        {

            var enrollment = await _context.Enrollment
        .FirstOrDefaultAsync(e => e.StudentId == StudentId && e.CourseId == CourseId);
            if (enrollment != null)
            {
                _context.Enrollment.Remove(enrollment);
                // Save changes to persist the deletion
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }

    }
}
