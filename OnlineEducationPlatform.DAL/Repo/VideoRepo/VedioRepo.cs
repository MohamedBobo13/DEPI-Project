using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repo.VideoRepo
{
    public class VedioRepo : IVedioRepo
    {
        private readonly EducationPlatformContext _context;

        public VedioRepo(EducationPlatformContext context)
        {
            _context = context;
        }

        public IEnumerable<Video> GetAll()
        {
            return _context.Video.AsNoTracking().Where(V => V.IsDeleted == false).ToList();
        }

        public Video GetById(int id)
        {
            var vedio = _context.Video.Find(id);
            if (vedio != null)
            {
                return vedio;
            }
            return null;
        }
        public void Add(Video video)
        {
            _context.Add(video);
            SaveChange();
        }

        public void Delete(int id)
        {
            var vedio = _context.Video.Find(id);
            if (vedio != null)
            {
                vedio.IsDeleted = true;
                SaveChange();
            }
        }
        public void Update(Video video)
        {
            SaveChange();
        }
        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
