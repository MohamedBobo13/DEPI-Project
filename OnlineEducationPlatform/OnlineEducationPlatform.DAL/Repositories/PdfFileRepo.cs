using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories
{
    public class PdfFileRepo : IPdfFileRepo
    {
        private readonly EducationPlatformContext _context;

        public PdfFileRepo(EducationPlatformContext context)
        {
            _context = context;
        }

        public IEnumerable<PdfFile> GetAll()
        {
            return _context.PdfFile.AsNoTracking().Where(P=>P.IsDeleted==false).ToList();
        }

        public PdfFile GetById(int id)
        {
            var PdfFile = _context.PdfFile.Find(id);
            if (PdfFile != null)
            {
                return PdfFile;
            }
            return null;
        }
        public void Add(PdfFile pdfFile)
        {
            _context.Add(pdfFile);
            SaveChange();
        }

        public void Delete(int id)
        {
            var file= _context.PdfFile.Find(id);
            if (file != null)
            {
                file.IsDeleted = true;
                SaveChange();
            }
        }
        public void Update(PdfFile pdfFile)
        {
            SaveChange();
        }
        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
