using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarShopMax.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet()]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("/home")]
    [Authorize]
    public IActionResult Home()
    {
        return View();
    }

}
