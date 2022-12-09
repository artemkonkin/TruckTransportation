using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Seller.App.Queries;
using TruckTransportation.Controllers._base;
using TruckTransportation.Models;

namespace TruckTransportation.Controllers;

public class SellerController : BaseController
{
    public SellerController(ILogger<HomeController> logger, IMediator mediator) : base(logger, mediator)
    {
    }
    
    public async Task<IActionResult> Index(GetSellersQuery query)
    {
        ViewData["Sellers"] = await Mediator.Send(query);
        return View(query);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}