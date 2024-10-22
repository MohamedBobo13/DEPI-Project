using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dto.CourseDto;
using OnlineEducationPlatform.BLL.Dto.LectureDto;
using OnlineEducationPlatform.BLL.Manager;

namespace OnlineEducationPlatform.Controllers
{
	public class LectureController : Controller
	{
		private readonly ILectureManager _lectureManager;

		public LectureController(ILectureManager lectureManager)
        {
			 _lectureManager = lectureManager;
		}

		public async Task<IActionResult> Index()
		{
			var lectures = await _lectureManager.GetAllAsync();
			return View(lectures);
		}

		public async Task<IActionResult> Details(int id)
		{
			var lecture = await _lectureManager.GetByIdAsync(id);

			if (lecture == null)
			{
				return NotFound();
			}
			else
			{
				return View(lecture);
			}
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<IActionResult> Create(LectureAddVm lectureAddVm)
		{
			if (!ModelState.IsValid)
			{
				return View(lectureAddVm);
			}
			await _lectureManager.AddAsync(lectureAddVm);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Edit(int id)
		{
			var lecture = await _lectureManager.GetByIdAsync(id);
			if (lecture == null)
			{
				return NotFound();
			}

			var lectureUpdateVm = new LectureUpdateVm
			{
				Title = lecture.Title,
				Order = lecture.Order,
			};

			return View(lectureUpdateVm);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(LectureUpdateVm lectureUpdateVm)
		{
			if (ModelState.IsValid)
			{
				await _lectureManager.UpdateAsync(lectureUpdateVm);
				return RedirectToAction(nameof(Index));
			}
			return View("Edit",lectureUpdateVm);
		}

		public async Task<IActionResult> Delete(int id)
		{
			var lecture = await _lectureManager.GetByIdAsync(id);
			if (lecture == null)
			{
				return NotFound();
			}

			return View(lecture);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await _lectureManager.DeleteAsync(id);

			return RedirectToAction("Index");
		}
	}
}
