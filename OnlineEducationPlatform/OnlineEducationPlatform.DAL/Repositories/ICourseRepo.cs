using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories
{
    public interface ICourseRepo
    {
        IEnumerable<Course> GetAll();
        Course GetById(int id);
        void Delete(Course course);
        void Update(Course course);
        void Add(Course course);
        void SaveChange();
    }
}
