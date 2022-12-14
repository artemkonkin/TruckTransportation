using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TruckTransportation.Controllers._base;
using TruckTransportation.Models;

namespace TruckTransportation.Controllers;

public class HomeController : BaseController
{
    public HomeController(ILogger<HomeController> logger, IMediator mediator) : base(logger, mediator)
    {
    }
    
    public IActionResult Index()
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