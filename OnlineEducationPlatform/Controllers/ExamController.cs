using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Manager.ExamManager;
using OnlineEducationPlatform.BLL.Manager.QuizManager;
using OnlineEducationPlatform.BLL.ViewModels.ExamDto;
using OnlineEducationPlatform.BLL.ViewModels.QuizDto;

namespace OnlineEducationPlatform.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExamManager _exammanager;
        public ExamController(IExamManager exammanager)
        {
            _exammanager = exammanager;
        }
        public async Task<IActionResult> Index()
        {
            var exam = await _exammanager.GetAllAsync();
            return View(exam);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExamAddVm examaddvm)
        {
            if (!ModelState.IsValid)
            {
                return View(examaddvm);
            }
            await _exammanager.AddAsync(examaddvm);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var exam = await _exammanager.GetByIdAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            var examupdate = new ExamUpdateVm
            {
                Id = exam.Id,
                CourseId = exam.CourseId,
                

                Title = exam.Title,
                TotalMarks = exam.TotalMarks,
                TotalQuestions = exam.TotalQuestions,
                DurationMinutes= exam.DurationMinutes,
                PassingMarks = exam.PassingMarks,

            };

            return View(examupdate);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ExamUpdateVm examvm)
        {
            if (ModelState.IsValid)
            {
                await _exammanager.Update(examvm);
                return RedirectToAction(nameof(Index));
            }
            return View(examvm);
        }

        public async Task<IActionResult> ConfirmSoftDelete(int id)
        {
            var exam = await _exammanager.GetByIdAsync(id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _exammanager.DeleteAsync(id);

            return RedirectToAction("Index");
        }

    }
}
