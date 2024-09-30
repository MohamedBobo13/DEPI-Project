using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories
{
    public interface IStudentProgressRepo
    {
        IEnumerable<StudentProgress> GetAll();
        StudentProgress GetById(int id);
        void Delete(StudentProgress studentProgress);
        void Update(StudentProgress studentProgress);
        void Add(StudentProgress studentProgress);
        void SaveChange();
    }
}
