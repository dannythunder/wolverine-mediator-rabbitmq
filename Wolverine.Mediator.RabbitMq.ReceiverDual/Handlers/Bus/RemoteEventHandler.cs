using Wolverine.Mediator.RabbitMq.Sender.Messages.Bus.Events;

namespace Wolverine.Mediator.RabbitMq.ReceiverDual.Handlers.Bus;

public class RemoteEventHandler
{
    public void Handle(RemoteEvent @event, ILogger<RemoteEventHandler> logger)
    {
        var className = GetType().Name;
        logger.LogInformation($"{@event.GetType().Name} with id {@event.Id} was received in {className}");
    }
}