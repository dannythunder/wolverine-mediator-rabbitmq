using Wolverine.Mediator.RabbitMq.Handlers.Bus.Command;

namespace Wolverine.Mediator.RabbitMq.Handlers.Bus;

public class RemoteCommandHandler
{
    public void Handle(RemoteCommand command, ILogger<RemoteCommandHandler> logger)
    {
        var className = GetType().Name;
        logger.LogInformation($"{command.GetType().Name} with id {command.Id} was received in {className}");
    }
}