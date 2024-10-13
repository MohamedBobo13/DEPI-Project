using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories.VideoRepo
{
    public class VideoRepo : IVideoRepo
    {
        private readonly EducationPlatformContext _context;

        public VideoRepo(EducationPlatformContext context)
        {
            _context = context;
        }

        public IEnumerable<Video> GetAll()
        {
            return _context.Video.AsNoTracking().ToList();
        }

        public Video GetById(int id)
        {
            return _context.Video.Find(id);
        }
        public void Add(Video video)
        {
            _context.Add(video);
        }

        public void Delete(Video video)
        {
            _context.Remove(video);
        }
        public void Update(Video video)
        {

        }
        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
