using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories
{
    public class AnswerResultRepo : IAnswerResultRepo
    {
        private readonly EducationPlatformContext _context;

        public AnswerResultRepo(EducationPlatformContext context)
        {
            _context = context;
        }

        public IEnumerable<AnswerResult> GetAll()
        {
            return _context.AnswerResult.AsNoTracking().ToList();
        }

        public AnswerResult GetById(int id)
        {
            return _context.AnswerResult.Find(id);
        }
        public void Add(AnswerResult answerResult)
        {
            _context.Add(answerResult);
        }

        public void Delete(AnswerResult answerResult)
        {
            answerResult.IsDeleted = true;
            _context.Update(answerResult);
        }
        public void Update(AnswerResult answerResult)
        {
            _context.Update(answerResult);
        }
        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}

