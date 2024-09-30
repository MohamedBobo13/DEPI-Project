using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories
{
    public interface IExamRepo
    {
        IEnumerable<Exam> GetAll();
        Exam GetById(int id);
        void Delete(Exam exam);
        void Update(Exam exam);
        void Add(Exam exam);
        void SaveChange();
    }
}
