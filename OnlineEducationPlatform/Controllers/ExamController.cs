using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Manager.ExamManager;
using OnlineEducationPlatform.BLL.ViewModels.ExamVm;
namespace OnlineEducationPlatform.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExamManager _examManager;
        public ExamController(IExamManager examManager)
        {
            _examManager = examManager;
        }
        public async Task<IActionResult> Index()
        {
            var ex = await _examManager.GetAllAsync();
            return View(ex);
        }
        public async Task<IActionResult> Details(int id)
        {
            var ex = await _examManager.GetByIdAsync(id);

            if (ex == null)
            {
                return NotFound();
            }

            return View(ex);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(ExamAddVm examAddVm)
        {
            if (examAddVm.CourseId <= 0)
            {
                ModelState.AddModelError("CourseId", "Invalid Course ID.");
                return View(examAddVm);
            }
            await _examManager.AddAsync(examAddVm);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var answer = await _examManager.GetByIdAsync(id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ExamUpdateVm examVm)
        {
            if (ModelState.IsValid)
            {
                await _examManager.UpdateAsync(examVm);
                return RedirectToAction(nameof(Index));
            }
            return View(examVm);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var answer = await _examManager.GetByIdAsync(id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _examManager.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}
