using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories
{
    public interface IEnrollmentRepo
    {
        IEnumerable<Enrollment> GetAll();
        Enrollment GetById(int id);
        void Delete(Enrollment enrollment);
        void Update(Enrollment enrollment);
        void Add(Enrollment enrollment);
        void SaveChange();
    }
}
