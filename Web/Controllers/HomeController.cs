using System.Diagnostics;
using Core.Application.VendistaApi;
using Core.Application.VendistaApi.Dto.Requests;
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

    public async Task<OkResult> SendCommand(int? terminalId = null, int? commandId = null, int? parameter1 = null, int? parameter2 = null,
        int? parameter3 = null, int? parameter4 = null, int? parameter5 = null, int? parameter6 = null, int? parameter7 = null, int? parameter8 = null,
        string? strParameter1 = null, string? strParameter2 = null)
    {
        if (terminalId == null || commandId == null)
            return Ok();

        var commandRequestDto = new CommandRequestDto { Id = commandId.Value };
        
        if (parameter1 != null)
            commandRequestDto.IntParams.Add(parameter1.Value);
        if (parameter2 != null)
            commandRequestDto.IntParams.Add(parameter2.Value);
        if (parameter3 != null)
            commandRequestDto.IntParams.Add(parameter3.Value);
        if (parameter4 != null)
            commandRequestDto.IntParams.Add(parameter4.Value);
        if (parameter5 != null)
            commandRequestDto.IntParams.Add(parameter5.Value);
        if (parameter6 != null)
            commandRequestDto.IntParams.Add(parameter6.Value);
        if (parameter7 != null)
            commandRequestDto.IntParams.Add(parameter7.Value);
        if (parameter8 != null)
            commandRequestDto.IntParams.Add(parameter8.Value);
        
        if (strParameter1 != null)
            commandRequestDto.StringParams.Add(strParameter1);
        if (strParameter2 != null)
            commandRequestDto.StringParams.Add(strParameter2);

        await _vendistaApi.SendCommandToTerminal(terminalId.Value, commandRequestDto);

        return Ok();
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

    private readonly VendistaApiInteractor _vendistaApi;
    
    private readonly ILogger<HomeController> _logger;
}