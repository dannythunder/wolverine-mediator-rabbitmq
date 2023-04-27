using Wolverine.Mediator.RabbitMq.ReceiverDual.Messages.Bus.Command;

namespace Wolverine.Mediator.RabbitMq.ReceiverDual.Handlers.Bus;

public class RemoteCommandConsumer
{
    public void Consume(ReceiverDualRemoteCommand command, ILogger<RemoteCommandConsumer> logger)
    {
        var className = GetType().Name;
        logger.LogInformation($"{command.GetType().Name} with id {command.Id} was received in {className}");
    }
}