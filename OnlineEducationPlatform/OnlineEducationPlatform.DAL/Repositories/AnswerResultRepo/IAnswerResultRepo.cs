using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories.AnswerResultRepo
{
    public interface IAnswerResultRepo
    {
        IEnumerable<AnswerResult> GetAll();
        AnswerResult GetById(int id);
        void Delete(AnswerResult answerResult);
        void Update(AnswerResult answerResult);
        void Add(AnswerResult answerResult);
        void SaveChange();
    }
}
