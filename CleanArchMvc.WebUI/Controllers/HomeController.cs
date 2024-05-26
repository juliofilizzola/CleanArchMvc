using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers;

public class HomeController : Controller {
    // GET
    public IActionResult Index() {
        return View();
    }
}