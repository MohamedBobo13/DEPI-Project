using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEducationPlatform.BLL.Manager.Answermanager;
using OnlineEducationPlatform.BLL.Manager.Questionmanager;
using OnlineEducationPlatform.BLL.ViewModels.AmswerVm;

namespace OnlineEducationPlatform.Controllers
{
    public class AnswerController : Controller
    {
        private readonly IAnswerManager _answerManager;
        private readonly IQuestionManager _questionManager;

        public AnswerController(IAnswerManager answerManager,IQuestionManager questionManager)
        {
            _answerManager = answerManager;
            _questionManager = questionManager;
        }
        public IActionResult Index()
        {
            var answer = _answerManager.GetAll();
             return View(answer);
        }
        public IActionResult Details(int id)
        {
            var answer = _answerManager.GetById(id); 

            if (answer == null)
            {
                return NotFound(); 
            }

            var viewModel = new AnswerDetailsVm
            {
                Id = answer.Id,
                AnswerText = answer.AnswerText,
                IsCorrect = answer.IsCorrect,
                QuestionText = answer.QuestionText 
            };

            return View(viewModel);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveCreate(AnswerAddVm answerVm)
        {
            if (ModelState.IsValid)
            {
                _answerManager.Add(answerVm);
                return RedirectToAction(nameof(Index));
            }
            return View(answerVm);
        }
        public IActionResult Edit(int id)
        {
            var answer = _answerManager.GetById(id);
            if (answer == null)
            {
                return NotFound();
            }

            var answerUpdateVm = new AnswerUpdateVm
            {
                Id = answer.Id,
                AnswerText = answer.AnswerText,
                IsCorrect = answer.IsCorrect,
                QuestionId = answer.QuestionId
            };

            return View(answerUpdateVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AnswerUpdateVm answerVm)
        {
            if (ModelState.IsValid)
            {
                _answerManager.Update(answerVm);
                return RedirectToAction(nameof(Index));
            }
            return View(answerVm);
        }
        public IActionResult Delete(int id)
        {
            var answer = _answerManager.GetById(id);
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
            _answerManager.Delete(id);

            return RedirectToAction("Index");
        }
        
    }
}
