using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dto.VideoDto;
using OnlineEducationPlatform.BLL.Manager;

namespace OnlineEducationPlatform.Controllers
{
    public class VedioController : Controller
    {
        private readonly IVedioManager _vedioManager;

        public VedioController(IVedioManager vedioManager)
        {
            _vedioManager = vedioManager;
        }

        public async Task<IActionResult> Index()
        {
            var vedios = await _vedioManager.GetAllAsync();
            return View(vedios);
        }

        public async Task<IActionResult> Details(int id)
        {
            var vedio = await _vedioManager.GetByIdAsync(id);

            if (vedio == null)
            {
                return NotFound();
            }
            else
            {
                return View(vedio);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(VedioAddVm vedioAddVm)
        {
            if (!ModelState.IsValid)
            {
                return View(vedioAddVm);
            }
            await _vedioManager.AddAsync(vedioAddVm);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var vedio = await _vedioManager.GetByIdAsync(id);
            if (vedio == null)
            {
                return NotFound();
            }

            var vedioUpdateVm = new VedioUpdateVm
            {
                Url = vedio.Url,
                Title = vedio.Title,
            };

            return View(vedioUpdateVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VedioUpdateVm vedioUpdateVm)
        {
            if (ModelState.IsValid)
            {
                await _vedioManager.UpdateAsync(vedioUpdateVm);
                return RedirectToAction(nameof(Index));
            }
            return View("Edit", vedioUpdateVm);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var vedio = await _vedioManager.GetByIdAsync(id);
            if (vedio == null)
            {
                return NotFound();
            }

            return View(vedio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _vedioManager.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}
