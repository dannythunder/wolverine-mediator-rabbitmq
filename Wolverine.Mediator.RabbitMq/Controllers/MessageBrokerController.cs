using Microsoft.AspNetCore.Mvc;
using Wolverine.Mediator.RabbitMq.Handlers.Mediator.Commands;
using Wolverine.Mediator.RabbitMq.Handlers.Mediator.Events;
using Wolverine.Mediator.RabbitMq.Messages.Bus.Command;
using Wolverine.Mediator.RabbitMq.Messages.Bus.Events;

namespace Wolverine.Mediator.RabbitMq.Controllers;

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
        await _bus.PublishAsync(remoteEvent);

        return Accepted();
    }
    
    [HttpPost]
    [Route("SendRemoteCommand")]
    public async Task<IActionResult> SendRemoteCommand()
    {
        var id = Guid.NewGuid();
        _logger.LogInformation($"Publishing RemoteCommand with id {id}");
        
        // Should be sent to rabbitmq
        var remoteCommand = new RemoteCommand(id);
        await _bus.SendAsync(remoteCommand);

        return Accepted();
    }
    
    [HttpPost]
    [Route("SendCrashCommand")]
    public async Task<IActionResult> SendCrashCommand()
    {
        var id = Guid.NewGuid();
        _logger.LogInformation($"Sending CrashCommand with id {id}");
        
        // Should be sent locally and crash since there is no handler for it.
        var crashCommand = new CrashCommand(id);
        await _bus.SendAsync(crashCommand);

        return Ok();
    }
}