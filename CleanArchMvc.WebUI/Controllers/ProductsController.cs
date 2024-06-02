using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchMvc.WebUI.Controllers
{
    public class ProductsController : Controller {
        private readonly ICategoryService _categoryService;
        private readonly IProductService  _productService;
        public ProductsController(IProductService productService, ICategoryService categoryService) {
            _productService  = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index() {
            var products = await _productService.GetProducts();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create() {
            var categories = await _categoryService.GetCategories();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto dto) {
            var dtoE = dto;
            if (!ModelState.IsValid) return await Create();
            await _productService.Add(dto);
            return RedirectToAction(nameof(Index));
        }


    }
}