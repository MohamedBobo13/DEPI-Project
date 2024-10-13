using OnlineEducationPlatform.DAL.Data.Models;

namespace OnlineEducationPlatform.DAL.Repositories.LectureRepo
{
    public interface ILectureRepo
    {
        IEnumerable<Lecture> GetAll();
        Lecture GetById(int id);
        void Delete(Lecture lecture);
        void Update(Lecture lecture);
        void Add(Lecture lecture);
        void SaveChange();
    }
}
