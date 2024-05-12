using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    public class ProductsController(IProductService productService) : Controller {
        [HttpGet]
        public async Task<IActionResult> Index() {
            var products = await productService.GetProducts();
            return View(products);
        }
    }
}