using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repo
{
    public interface Irepo
    {
        
      
        Task<IEnumerable<Enrollment>> GetByStudentIdAsync(string studentId);
        Task<IEnumerable<Enrollment>> GetByCourseIdAsync(int courseId);
        Task AddAsync(Enrollment enrollment);
     
        Task<bool> RemoveAsync(string studentId, int courseId);
        Task<bool> StudentExistsAsync(string studentId);
        Task<bool> CourseExistsAsync(int CourseId);
        Task<bool> EnrollmentExistsAsync(string studentId, int courseId);
        Task<bool> CompleteAsync();
      


    }
}
