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

    [HttpDelete]
    public async Task<IActionResult> Delete(int id) {
        var category = await _categoryService.Remove(id);
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
        if (ModelState.IsValid) {
            await _categoryService.Add(category);
            return RedirectToAction(nameof(System.Index));
        }

        return View(category);
    }
}