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
    public class EnrollmentRepo : IEnrollmentRepo
    {
        private readonly EducationPlatformContext _context;

        public EnrollmentRepo(EducationPlatformContext context)
        {
            _context = context;
        }

        public IEnumerable<Enrollment> GetAll()
        {
            return _context.Enrollment.AsNoTracking().ToList();
        }

        public Enrollment GetById(int id)
        {
            return _context.Enrollment.Find(id);
        }
        public void Add(Enrollment enrollment)
        {
            _context.Add(enrollment);
        }

        public void Delete(Enrollment enrollment)
        {
            _context.Remove(enrollment);
        }
        public void Update(Enrollment enrollment)
        {

        }
        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
