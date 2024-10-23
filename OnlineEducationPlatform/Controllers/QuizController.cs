using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Manager.QuizManager;
using OnlineEducationPlatform.BLL.ViewModels.ExamVm;
using OnlineEducationPlatform.BLL.ViewModels.QuizViewModel;
namespace OnlineEducationPlatform.Controllers
{
    public class QuizController : Controller
    {
        private readonly IQuizManager _quizManager;
        public QuizController(IQuizManager quizManager)
        {
            _quizManager = quizManager;
        }
        public async Task<IActionResult> Index()
        {
            var quiz = await _quizManager.GetAllAsync();
            return View(quiz);
        }
        public async Task<IActionResult> Details(int id)
        {
            var quiz = await _quizManager.GetByIdAsync(id);

            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuizAddVm quizAddVm)
        {
            if (quizAddVm.CourseId <= 0)
            {
                ModelState.AddModelError("CourseId", "Invalid Course ID.");
                return View(quizAddVm);
            }
            await _quizManager.AddAsync(quizAddVm);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var answer = await _quizManager.GetByIdAsync(id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(QuizUpdateVm quizVm)
        {
            if (ModelState.IsValid)
            {
                await _quizManager.UpdateAsync(quizVm);
                return RedirectToAction(nameof(Index));
            }
            return View(quizVm);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var answer = await _quizManager.GetByIdAsync(id);
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
            await _quizManager.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}
