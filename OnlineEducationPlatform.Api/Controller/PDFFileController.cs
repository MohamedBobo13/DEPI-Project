using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.BLL.Manager;

namespace OnlineEducationPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDFFileController : ControllerBase
    {
        private readonly IPdfFileManager _pdfFileManager;

        public PDFFileController(IPdfFileManager pdfFileManager)
        {
            _pdfFileManager = pdfFileManager;
        }

        [HttpGet]
        //Instructor and Student can get all PdfFiles
        public ActionResult GetAllPDF()
        {
            var AllFiles=_pdfFileManager.GetAll();
            if (AllFiles != null)
            {
                return Ok(AllFiles);
            }
            return NotFound();
        }

        [HttpGet("{id:int}")]
        //Instructor and Student can get PdfFile
        public ActionResult GetPDF(int id)
        {
            var PdfFile=_pdfFileManager.GetById(id);
            if (PdfFile != null)
            {
                return Ok(PdfFile);
            }
            return NotFound();
        }

        [HttpPost]
        // Instructor only can be add PdfFile
        public ActionResult AddPDF(PdfFileAddDto pdfFileAddDto)
        {
            _pdfFileManager.Add(pdfFileAddDto);
            return Created();
        }
        [HttpPut]
        // Instructor only can be update PdfFile
        public ActionResult UpdatePDF(PdfFileUpdateDto pdfFileUpdateDto)
        {
            _pdfFileManager.Update(pdfFileUpdateDto);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        // Instructor only can be delete PdfFile
        public ActionResult DeletePDF(int id)
        {
            _pdfFileManager.Delete(id);
            return Ok();
        }
    }
}
