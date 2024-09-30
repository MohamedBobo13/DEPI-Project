using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories
{
    public interface IPdfFileRepo
    {
        IEnumerable<PdfFile> GetAll();
        PdfFile GetById(int id);
        void Delete(PdfFile pdfFile);
        void Update(PdfFile pdfFile);
        void Add(PdfFile pdfFile);
        void SaveChange();
    }
}
