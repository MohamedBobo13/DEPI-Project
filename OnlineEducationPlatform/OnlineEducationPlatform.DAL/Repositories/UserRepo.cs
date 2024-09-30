using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly EducationPlatformContext _context;

        public UserRepo(EducationPlatformContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User.AsNoTracking().ToList();
        }

        public User GetById(int id)
        {
            return _context.User.Find(id);
        }
        public void Add(User user)
        {
            _context.Add(user);
        }

        public void Delete(User user)
        {
            _context.Remove(user);
        }
        public void Update(User user)
        {

        }
        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
