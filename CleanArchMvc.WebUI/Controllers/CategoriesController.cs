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
}