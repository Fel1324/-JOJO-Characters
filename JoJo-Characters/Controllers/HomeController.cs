using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JoJo_Characters.Models;
using JoJo_Characters.Services;

namespace JoJo_Characters.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IJojoService _jojoService;

    public HomeController(ILogger<HomeController> logger, IJojoService jojoService)
    {
        _logger = logger;
        _jojoService = jojoService;
    }

    public IActionResult Index(string parte)
    {
        var persos = _jojoService.GetPersonagemDto();
        ViewData["filter"] = string.IsNullOrEmpty(parte) ? "all" : parte;
        return View(persos);
    }

    public IActionResult Details(string Nome)
    {
        var personagem = _jojoService.GetDetailedPersonagem(Nome);
        return View(personagem);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
