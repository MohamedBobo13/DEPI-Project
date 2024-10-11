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
        public IActionResult GetAllPDF()
        {
            return Ok(_pdfFileManager.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPDF(int id)
        {
            return Ok(_pdfFileManager.GetById(id));
        }

        [HttpPost]
        public IActionResult AddPDF(PdfFileAddDto pdfFileAddDto)
        {
            _pdfFileManager.Add(pdfFileAddDto);
            return Created();
        }
        [HttpPut]

        public IActionResult UpdatePDF(PdfFileUpdateDto pdfFileUpdateDto)
        {
            _pdfFileManager.Update(pdfFileUpdateDto);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeletePDF(int id)
        {
            _pdfFileManager.Delete(id);
            return Ok();
        }
    }
}
