using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories.PdfFileRepo
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
            return _context.PdfFile.AsNoTracking().ToList();
        }

        public PdfFile GetById(int id)
        {
            return _context.PdfFile.Find(id);
        }
        public void Add(PdfFile pdfFile)
        {
            _context.Add(pdfFile);
        }

        public void Delete(PdfFile pdfFile)
        {
            _context.Remove(pdfFile);
        }
        public void Update(PdfFile pdfFile)
        {

        }
        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
