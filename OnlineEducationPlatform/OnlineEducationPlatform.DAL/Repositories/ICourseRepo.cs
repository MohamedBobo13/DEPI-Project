using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories
{
    public interface ICourseRepo
    {
        void Add(Course course);
        IEnumerable<Course> GetAll();
        Course GetById(int id);
        void Update(Course course);
        void Delete(int id);
        void SaveChanges();
    }
}
