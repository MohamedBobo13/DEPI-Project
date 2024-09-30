using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories
{
    public interface IExamResultRepo
    {
        IEnumerable<ExamResult> GetAll();
        ExamResult GetById(int id);
        void Delete(ExamResult examResult);
        void Update(ExamResult examResult);
        void Add(ExamResult examResult);
        void SaveChange();
    }
}
