using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AmandaViagens.Models;
using AmandaViagens.Data;

namespace AmandaViagens.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(
        ILogger<HomeController> logger, AppDbContext context
        )
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var pontos = _context.PontoTuristicos.ToList();
        return View(pontos);
    }

    public IActionResult Ingressos()
    {
        var ingresso = _context.Ingressos.ToList();
        return View(ingresso);
    }

     public IActionResult Cruzeiros()
    {
        var cruzeiros = _context.Cruzeiros.ToList();
        return View(cruzeiros);
    }

     public IActionResult Feedback()
    {
        return View();
    }

     public IActionResult Sobre()
    {
        return View();
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
