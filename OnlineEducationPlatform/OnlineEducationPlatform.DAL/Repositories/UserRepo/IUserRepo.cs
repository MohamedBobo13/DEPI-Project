using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories.UserRepo
{ 
    public interface IUserRepo
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Delete(User user);
        void Update(User user);
        void Add(User user);
        void SaveChange();
    }
}
