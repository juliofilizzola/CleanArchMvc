using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchMvc.WebUI.Controllers
{
    public class ProductsController : Controller {
        private readonly ICategoryService    _categoryService;
        private readonly IProductService     _productService;
        private readonly IWebHostEnvironment _environment;
        public ProductsController(IProductService productService, ICategoryService categoryService,
                                  IWebHostEnvironment environment) {
            _productService  = productService;
            _categoryService = categoryService;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index() {
            try {
                var products = await _productService.GetProducts();
                return View(products);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return View("NotFoundProduct");;
            }
        }

        [HttpGet]
        public IActionResult NotFoundProduct() {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create() {
            var categories = await _categoryService.GetCategories();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto dto) {
            if (!ModelState.IsValid) return await Create();
            await _productService.Add(dto);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var product = await _productService.GetProductById(id);
            if (product == null) {
                return NotFound();
            }

            var categories = await _categoryService.GetCategories();

            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", product.Category);

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id) {
            if (id == null){
                return View("NotFoundProduct");
            }

            var product = await _productService.GetProductById(id);

            if (product == null){
                return View("NotFoundProduct");
            }

            return View(product);
        }


        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> Delete(int id) {
            var productRemove = await _productService.Remove(id);
            if (productRemove){
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id) {
            var product = await _productService.GetProductById(id);
            if (product == null){
                return View("NotFoundProduct");
            }
            var wwwroot = _environment.WebRootPath;
            var image   = Path.Combine(wwwroot, "images\\" + product.Image);
            var exists  = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;
            return View(product);
        }
    }
}