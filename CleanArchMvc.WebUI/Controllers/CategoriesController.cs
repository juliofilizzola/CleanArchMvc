using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers;

public class CategoriesController(ICategoryService categoryService) : Controller {
    private readonly ICategoryService _categoryService = categoryService;

    [HttpGet]
    public async Task<IActionResult> Index() {
        var categories = await _categoryService.GetCategories();

        return View(categories);
    }

    [HttpGet]
    public IActionResult Delete() {
        return View();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int? id) {
        if (id == null) return NotFound();

        var category = await _categoryService.Remove(id);
        if (category) {
            return RedirectToAction(nameof(System.Index));
        }
        return View();
    }

    [HttpGet]
    public IActionResult Create() {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id) {
        if (id == null) {
            return NotFound();
        }

        var categoryDto = await _categoryService.GetById(id);

        if (categoryDto == null) return NotFound();

        return View(categoryDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryDto category) {
        if (!ModelState.IsValid) return View(category);
        await _categoryService.Add(category);
        return RedirectToAction(nameof(System.Index));

    }

    [HttpPost]
    public async Task<IActionResult> Edit(CategoryDto categoryDto) {
        if (!ModelState.IsValid) return View(categoryDto);

        try {
            await _categoryService.Update(categoryDto);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }

        return RedirectToAction(nameof(Index));
    }
}