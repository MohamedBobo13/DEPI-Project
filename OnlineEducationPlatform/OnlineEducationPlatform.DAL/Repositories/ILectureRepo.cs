using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories
{
    public interface ILectureRepo
    {
        IEnumerable<Lecture> GetAll();
        Lecture GetById(int id);
        //Lecture GetByCourse(Course course);
        void Delete(int id);
        void Update(Lecture lecture);
        void Add(Lecture lecture);
        void SaveChange();
    }
}
