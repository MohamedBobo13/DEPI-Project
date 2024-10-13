using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories.AnswerRepo
{
    public class AnswerRepo : IAnswerRepo
    {
        private readonly EducationPlatformContext _context;

        public AnswerRepo(EducationPlatformContext context)
        {
            _context = context;
        }

        public IEnumerable<Answer> GetAll()
        {
            return _context.Answer.AsNoTracking().ToList();
        }

        public Answer GetById(int id)
        {
            return _context.Answer.Find(id);
        }
        public void Add(Answer answer)
        {
            _context.Add(answer);
        }

        public void Delete(Answer answer)
        {
            _context.Remove(answer);
        }
        public void Update(Answer answer)
        {

        }
        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
