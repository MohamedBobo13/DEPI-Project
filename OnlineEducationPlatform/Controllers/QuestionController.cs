using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dto.QuestionDto;
using OnlineEducationPlatform.BLL.Manager.Questionmanager;

namespace OnlineEducationPlatform.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionManager _questionManager;
        private readonly IMapper _mapper;

        public QuestionController(IQuestionManager questionManager,IMapper mapper)
        {
            _questionManager = questionManager;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var questions = _questionManager.GetAll();
            return View(questions);
        }
        public IActionResult QuizQuestions()
        {
            var quizQuestions = _questionManager.GetQuiz();
            return View(quizQuestions);
        }
        public IActionResult ExamQuestions()
        {
            var examQuestions = _questionManager.GetExam();
            return View(examQuestions);
        }
        public IActionResult Details(int id)
        {
            var question = _questionManager.GetById(id);

            if (question == null)
            {
                return NotFound(); 
            }

            return View(question); 
        }

        public IActionResult SelectCourseForExam()
        {
            return View();
        }

        public IActionResult SelectCourseForQuiz()
        {
            return View();
        }

        public IActionResult CourseQuiz(int courseId)
        {
            var quizQuestions = _questionManager.GetCourseQuiz(courseId);
            return View(quizQuestions);
        }

        public IActionResult CourseExam(int courseId)
        {
            var examQuestions = _questionManager.GetCourseExam(courseId);
            return View(examQuestions);
        }
        public IActionResult CreateQuiz()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateQuiz(QuestionQuizAddVm model)
        {
            if (ModelState.IsValid)
            {
                _questionManager.AddQuiz(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult CreateExam()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateExam(QuestionExamAddVm model)
        {
            if (ModelState.IsValid)
            {
                _questionManager.AddExam(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult EditQuiz(int id)
        {
            var question = _questionManager.GetById(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<QuestionQuizUpdateVm>(question));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditQuiz(QuestionQuizUpdateVm model)
        {
            if (ModelState.IsValid)
            {
                _questionManager.UpdateQuiz(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult EditExam(int id)
        {
            var question = _questionManager.GetById(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<QuestionExamUpdateVm>(question));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditExam(QuestionExamUpdateVm model)
        {
            if (ModelState.IsValid)
            {
                _questionManager.UpdateExam(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var question = _questionManager.GetById(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _questionManager.Delete(id);
            TempData["Message"] = "Question successfully deleted.";
            return RedirectToAction(nameof(Index));
        }
    }
}

