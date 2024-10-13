using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories.AnswerResultRepo
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
            _context.Remove(answerResult);
        }
        public void Update(AnswerResult answerResult)
        {

        }
        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}

