using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories.QuizResultRepo
{
    public class QuizResultRepo : IQuizResultRepo
    {
        private readonly EducationPlatformContext _context;

        public QuizResultRepo(EducationPlatformContext context)
        {
            _context = context;
        }

        public IEnumerable<QuizResult> GetAll()
        {
            return _context.QuizResult.AsNoTracking().ToList();
        }

        public QuizResult GetById(int id)
        {
            return _context.QuizResult.Find(id);
        }
        public void Add(QuizResult quizResult)
        {
            _context.Add(quizResult);
        }

        public void Delete(QuizResult quizResult)
        {
            _context.Remove(quizResult);
        }
        public void Update(QuizResult quizResult)
        {

        }
        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
