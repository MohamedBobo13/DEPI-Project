using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories.ExamRepo
{
    public interface IExamRepo
    {
        Task<List<Exam>> GetAll();
        Task<Exam> GetById(int id);
        Task Add(Exam exam);
        Task Update(Exam exam);
        Task<bool> Delete(int id);
        Task SaveChange();
        
    }
}
