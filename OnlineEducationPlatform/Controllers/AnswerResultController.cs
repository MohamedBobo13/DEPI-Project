﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;

public class AnswerResultController : Controller
{
    private readonly IAnswerResultManager _answerResultManager;
    private readonly IMapper _mapper;

    public AnswerResultController(IAnswerResultManager answerResultManager,IMapper mapper)
    {
        _answerResultManager = answerResultManager;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var answerResults = await _answerResultManager.GetAllAsync();
        return View(answerResults);
    }

    public async Task<IActionResult> Details(int id)
    {
        var answerResult = await _answerResultManager.GetByIdAsync(id);
        return View(answerResult);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AnswerResultAddVm answerResultAddVm)
    {
        if (ModelState.IsValid)
        {
                await _answerResultManager.AddAsync(answerResultAddVm);
                return RedirectToAction(nameof(Index));
        }
        return View(answerResultAddVm);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var answerResult = await _answerResultManager.GetByIdAsync(id);
        var answerResultUpdateVm = _mapper.Map<AnswerResultUpdateVm>(answerResult);
        return View(answerResultUpdateVm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(AnswerResultUpdateVm answerResultUpdateVm)
    {
        if (ModelState.IsValid)
        {
            await _answerResultManager.UpdateAsync(answerResultUpdateVm);
            return RedirectToAction(nameof(Index));
        }
        return View(answerResultUpdateVm);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var answerResult = await _answerResultManager.GetByIdAsync(id);
        return View(answerResult);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var answerResult = await _answerResultManager.GetByIdAsync(id);
        if (answerResult == null)
        {
            return NotFound();
        }

        await _answerResultManager.DeleteAsync(_mapper.Map<AnswerResult>(answerResult));
        return RedirectToAction(nameof(Index));
    }
}
