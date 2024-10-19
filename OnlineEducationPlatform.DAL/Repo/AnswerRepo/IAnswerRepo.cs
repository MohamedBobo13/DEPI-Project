using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories
{
    public interface IAnswerRepo
    {
        IEnumerable<Answer> GetAll();
        Answer GetById(int id);
        void Delete(Answer answer);
        void Update(Answer answer);
        void Add(Answer answer);
        void SaveChange();
    }
}
