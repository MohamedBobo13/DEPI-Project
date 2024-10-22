using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dto.LectureDto;
using OnlineEducationPlatform.BLL.Manager;

namespace OnlineEducationPlatform.Controllers
{
    public class PdfController : Controller
    {
        private readonly IPdfFileManager _pdfFileManager;

        public PdfController(IPdfFileManager pdfFileManager)
        {
            _pdfFileManager = pdfFileManager;
        }

        public async Task<IActionResult> Index()
        {
            var pdfs = await _pdfFileManager.GetAllAsync();
            return View(pdfs);
        }

        public async Task<IActionResult> Details(int id)
        {
            var pdf = await _pdfFileManager.GetByIdAsync(id);

            if (pdf == null)
            {
                return NotFound();
            }
            else
            {
                return View(pdf);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(PdfFileAddVm pdfFileAddVm)
        {
            if (!ModelState.IsValid)
            {
                return View(pdfFileAddVm);
            }
            await _pdfFileManager.AddAsync(pdfFileAddVm);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var pdf = await _pdfFileManager.GetByIdAsync(id);
            if (pdf == null)
            {
                return NotFound();
            }

            var pdfFileUpdateVm = new PdfFileUpdateVm
            {
                Url=pdf.Url,
                Title = pdf.Title,
            };

            return View(pdfFileUpdateVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PdfFileUpdateVm pdfFileUpdateVm)
        {
            if (ModelState.IsValid)
            {
                await _pdfFileManager.UpdateAsync(pdfFileUpdateVm);
                return RedirectToAction(nameof(Index));
            }
            return View("Edit", pdfFileUpdateVm);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var pdf = await _pdfFileManager.GetByIdAsync(id);
            if (pdf == null)
            {
                return NotFound();
            }

            return View(pdf);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _pdfFileManager.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}
