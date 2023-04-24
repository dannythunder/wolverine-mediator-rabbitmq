using DoesItWork.Handlers.Bus.Events;
using DoesItWork.Handlers.Mediator.Commands;
using DoesItWork.Handlers.Mediator.Events;
using Microsoft.AspNetCore.Mvc;
using Wolverine;

namespace DoesItWork.Controllers;

[ApiController]
[Route("[controller]")]
public class MessageBrokerController : ControllerBase
{
    private readonly ILogger<MessageBrokerController> _logger;
    private readonly IMessageBus _bus;

    public MessageBrokerController(ILogger<MessageBrokerController> logger, IMessageBus bus)
    {
        _logger = logger;
        _bus = bus;
    }

    [HttpPost]
    [Route("SendLocalCommand")]
    public async Task<IActionResult> SendLocalCommand()
    {
        var localCommand = new LocalCommand(Guid.NewGuid());
        await _bus.SendAsync(localCommand);
        return Accepted();
    }
    
    [HttpPost]
    [Route("SendLocalEvent")]
    public async Task<IActionResult> SendLocalEvent()
    {
        // Should be received by two handlers
        var localEvent = new LocalEvent(Guid.NewGuid());
        await _bus.PublishAsync(localEvent);
        return Accepted();
    }
    
    [HttpPost]
    [Route("SendRemoteEvent")]
    public async Task<IActionResult> SendRemoteEvent()
    {
        var remoteEvent = new RemoteEvent(Guid.NewGuid());
        await _bus.SendAsync(remoteEvent);
        return Accepted();
    }
}