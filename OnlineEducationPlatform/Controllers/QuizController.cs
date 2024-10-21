using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Manager.QuizManager;
using OnlineEducationPlatform.BLL.QuizVm;
using OnlineEducationPlatform.BLL.ViewModels.QuizVm;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repo.QuizRepo;
namespace OnlineEducationPlatform.Controllers
{
    public class QuizController : Controller
    {
        private readonly IQuizManager _quizManager;
        public QuizController(IQuizManager quizManager)
        {
            _quizManager = quizManager;
        }
        public IActionResult Index()
        {
            var quiz = _quizManager.GetAllAsync();
            return View(quiz);
        }
        public IActionResult Details(int id)
        {
            var quiz = _quizManager.GetByIdAsync(id);

            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(QuizAddVm quizAddVm)
        {
            if (!ModelState.IsValid)
            {
                return View(quizAddVm);
            }
            _quizManager.AddAsync(quizAddVm);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var answer = _quizManager.GetByIdAsync(id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(QuizUpdateVm quizVm)
        {
            if (ModelState.IsValid)
            {
                _quizManager.UpdateAsync(quizVm);
                return RedirectToAction(nameof(Index));
            }
            return View(quizVm);
        }
        public IActionResult Delete(int id)
        {
            var answer = _quizManager.GetByIdAsync(id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _quizManager.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}
