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
    public class QuizRepo : IQuizRepo
    {
        private readonly EducationPlatformContext _context;

        public QuizRepo(EducationPlatformContext context)
        {
            _context = context;
        }

        public IEnumerable<Quiz> GetAll()
        {
            return _context.Quiz.AsNoTracking().ToList();
        }

        public Quiz GetById(int id)
        {
            return _context.Quiz.Find(id);
        }
        public void Add(Quiz quiz)
        {
            _context.Add(quiz);
        }

        public void Delete(Quiz quiz)
        {
            _context.Remove(quiz);
        }
        public void Update(Quiz quiz)
        {

        }
        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
