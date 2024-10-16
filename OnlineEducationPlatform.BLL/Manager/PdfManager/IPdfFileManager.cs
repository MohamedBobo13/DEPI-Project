using OnlineEducationPlatform.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager
{
    public interface IPdfFileManager
    {
        void Add(PdfFileAddDto pdfFileAddDto);
        IEnumerable<PdfFileReadDto> GetAll();

        PdfFileReadDto GetById(int id);

        void Update(PdfFileUpdateDto pdfFileUpdateDto);

        void Delete(int id);

        void SaveChanges();

    }
}
