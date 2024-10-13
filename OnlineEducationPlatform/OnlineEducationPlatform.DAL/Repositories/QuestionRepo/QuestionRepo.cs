using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories.QuestionRepo
{
    public class QuestionRepo : IQuestionRepo
    {
        private readonly EducationPlatformContext _context;

        public QuestionRepo(EducationPlatformContext context)
        {
            _context = context;
        }

        public IEnumerable<Question> GetAll()
        {
            return _context.Question.AsNoTracking().ToList();
        }

        public Question GetById(int id)
        {
            return _context.Question.Find(id);
        }
        public void Add(Question question)
        {
            _context.Add(question);
        }

        public void Delete(Question question)
        {
            _context.Remove(question);
        }
        public void Update(Question question)
        {

        }
        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
