using Microsoft.AspNetCore.Mvc;

namespace Wolverine.Mediator.RabbitMq.ReceiverDual.Controllers;

[ApiController]
[Route("[controller]")]
public class NotImplementedController : ControllerBase
{
    private readonly ILogger<NotImplementedController> _logger;

    public NotImplementedController(ILogger<NotImplementedController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return BadRequest("Nothing is implemented here yet");
    }
}