using CleanArchMvc.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers;

public class HomeController : Controller {
    // GET
    public IActionResult Index() {
        return View();
    }


    [Route("Home/Error")]
    public IActionResult Error(int statusCode)
    {
        var viewModel = new ErrorViewModel { StatusCode = statusCode };

        switch (statusCode)
        {
            case 404:
                viewModel.Message = "Página não encontrada";
                break;
            case 500:
                viewModel.Message = "Erro interno do servidor";
                break;
            default:
                viewModel.Message = "Ocorreu um erro inesperado";
                break;
        }

        return View(viewModel);
    }
}