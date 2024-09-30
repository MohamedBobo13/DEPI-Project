using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories
{
    public interface IVideoRepo
    {
        IEnumerable<Video> GetAll();
        Video GetById(int id);
        void Delete(Video video);
        void Update(Video video);
        void Add(Video video);
        void SaveChange();
    }
}
