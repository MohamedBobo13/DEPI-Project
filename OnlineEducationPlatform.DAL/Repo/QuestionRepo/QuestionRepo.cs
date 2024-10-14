using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repo.QuestionRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories
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
        public IEnumerable<Question> GetAllExam()
        {
            return _context.Question.Where(e=>e.ExamId!=null).AsNoTracking().ToList();
        }

        public IEnumerable<Question> GetAllQuiz()
        {
            return _context.Question.Where(q => q.QuizId != null).AsNoTracking().ToList();
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
            question.IsDeleted = true;
            _context.Update(question);
        }
        public void Update(Question question)
        {
            _context.Update(question);
        }
        public void SaveChange()
        {
            _context.SaveChanges();
        }

        public bool ExamExists(int? examId)
        {
            return _context.Question.Any(e => e.ExamId == examId);
        }
        public bool QuizExists(int? QuizId)
        {
            return _context.Question.Any(e => e.QuizId == QuizId);
        }
    }
}
