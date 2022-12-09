using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TruckTransportation.Controllers._base;

public class BaseController : Controller
{
    protected readonly ILogger<HomeController> Logger;
    protected readonly IMediator Mediator;

    public BaseController(ILogger<HomeController> logger, IMediator mediator)
    {
        Logger = logger;
        Mediator = mediator;
    }
}