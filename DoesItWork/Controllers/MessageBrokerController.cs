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
        var id = Guid.NewGuid();
        _logger.LogInformation($"Sending LocalCommand with id {id}");
        
        // Should be received by one handlers
        var localCommand = new LocalCommand(id);
        await _bus.InvokeAsync(localCommand);
        return Accepted();
    }
    
    [HttpPost]
    [Route("SendLocalEvent")]
    public async Task<IActionResult> SendLocalEvent()
    {
        var id = Guid.NewGuid();
        _logger.LogInformation($"Publishing LocalEvent with id {id}");
        
        // Should be received by two handlers
        var localEvent = new LocalEvent(id);
        await _bus.PublishAsync(localEvent);
        return Accepted();
    }
    
    [HttpPost]
    [Route("SendRemoteEvent")]
    public async Task<IActionResult> SendRemoteEvent()
    {
        var id = Guid.NewGuid();
        _logger.LogInformation($"Publishing RemoteEvent with id {id}");
        
        // Should be sent to rabbitmq
        var remoteEvent = new RemoteEvent(id);
        await _bus.SendAsync(remoteEvent);
        return Accepted();
    }
    
    [HttpPost]
    [Route("SendCrashCommand")]
    public async Task<IActionResult> SendCrashCommand()
    {
        var id = Guid.NewGuid();
        _logger.LogInformation($"Sending CrashCommand with id {id}");
        
        // Should be sent to rabbitmq
        var crashCommand = new CrashCommand(id);
        
        try
        {
            await _bus.InvokeAsync(crashCommand);
            return Accepted();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}