using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DBHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repo.QuestionRepo
{
    public class QuestionRepo : IQuestionRepo
    {
        private readonly EducationPlatformContext _context;

        public QuestionRepo(EducationPlatformContext context)
        {
            _context = context;
        }
        public IQueryable<Question> GetAll()
        {
            return  _context.Question.AsNoTracking();
        }

        public IQueryable<Question> GetCourseExam(int courseId)
        {
            return  _context.Question.Where(q => q.QuizId == null && q.CourseId == courseId);
            
        }

        public IQueryable<Question> GetCourseQuiz(int courseId)
        {
            return  _context.Question.Where(q => q.ExamId == null && q.CourseId == courseId);
        }

        public Question GetById(int id)
        {
            return  _context.Question.FirstOrDefault(a => a.Id == id);
        }
        public void Add(Question question)
        {
             _context.Add(question);
            SaveChange();
        }
        public void Update(Question question)
        {
            _context.Update(question);
            SaveChange();
        }
        public void Delete(Question question)
        {
            question.IsDeleted = true;
            _context.Update(question);
            SaveChange();
        }

        //public async Task<bool> IdForExam(int questionId)
        //{
        //    bool idforExam = await _context.Question.Where(q=>q.QuizId == null).AnyAsync(q=>q.Id == questionId);
        //    if(idforExam)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public async Task<bool> IdForQuiz(int questionId)
        //{
        //    bool idforQuiz = await _context.Question.Where(q => q.ExamId == null).AnyAsync(q => q.Id == questionId);
        //    if (idforQuiz)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public async Task<bool> QuizIdExist(int quizId)
        //{
        //    var quizExist = await _context.Quiz.AnyAsync(q => q.Id == quizId);
        //    if (quizExist)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public async Task<bool> ExamIdExist(int examId)
        //{
        //    var examExist = await _context.Exam.AnyAsync(e => e.Id == examId);
        //    if (examExist)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public async Task<bool> CourseIdExist(int courseId)
        //{
        //    var courseExist = await _context.Course.AnyAsync(c => c.Id == courseId);
        //    if (courseExist)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public void SaveChange()
        {
             _context.SaveChanges();
        }

        
    }
}