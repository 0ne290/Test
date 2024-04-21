using System.Diagnostics;
using Core.Application.VendistaApi;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers;

public class HomeController : Controller
{
    public HomeController(VendistaApiInteractor vendistaApi, ILogger<HomeController> logger)
    {
        _logger = logger;
        _vendistaApi = vendistaApi;
    }

    public async Task<IActionResult> Index()
    {
        ViewData["TerminalIDs"] = await _vendistaApi.GetIDsOfAllTerminals();
        ViewData["Commands"] = await _vendistaApi.GetAllCommands();
        return View();
    }
    
    public async Task<JsonResult> GetCommandsByTerminal(int terminalId) => Json(await _vendistaApi.GetCommandsByTerminal(terminalId));

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private readonly VendistaApiInteractor _vendistaApi;
    
    private readonly ILogger<HomeController> _logger;
}