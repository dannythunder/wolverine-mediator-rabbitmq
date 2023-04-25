using Wolverine.Mediator.RabbitMq.Messages.Bus.Command;

namespace Wolverine.Mediator.RabbitMq.Receiver.Handlers.Bus;

public class RemoteCommandConsumer
{
    public void Consume(RemoteCommand command, ILogger<RemoteCommandConsumer> logger)
    {
        var className = GetType().Name;
        logger.LogInformation($"{command.GetType().Name} with id {command.Id} was received in {className}");
    }
}