using Wolverine.Mediator.RabbitMq.Handlers.Bus.Command;

namespace Wolverine.Mediator.RabbitMq.Handlers.Bus;

public class RemoteCommandConsumer
{
    public void Consume(RemoteCommand command, ILogger<RemoteCommandConsumer> logger)
    {
        var className = GetType().Name;
        logger.LogInformation($"{command.GetType().Name} with id {command.Id} was received in {className}");
    }
}