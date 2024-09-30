using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories
{
    public interface IQuestionRepo
    {
        IEnumerable<Question> GetAll();
        Question GetById(int id);
        void Delete(Question question);
        void Update(Question question);
        void Add(Question question);
        void SaveChange();
    }
}
