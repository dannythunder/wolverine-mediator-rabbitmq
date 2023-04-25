using Wolverine.Mediator.RabbitMq.Messages.Bus.Events;

namespace Wolverine.Mediator.RabbitMq.Receiver.Handlers.Bus;

public class RemoteEventHandler
{
    public void Handle(RemoteEvent @event, ILogger<RemoteEventHandler> logger)
    {
        var className = GetType().Name;
        logger.LogInformation($"{@event.GetType().Name} with id {@event.Id} was received in {className}");
    }
}