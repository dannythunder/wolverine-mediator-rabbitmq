using Wolverine.Mediator.RabbitMq.Handlers.Mediator.Events;

namespace Wolverine.Mediator.RabbitMq.Handlers.Mediator;

public class LocalBroadcast2Handler
{
    public void Handle(LocalEvent @event, ILogger<LocalBroadcast2Handler> logger)
    {
        var className = GetType().Name;
        logger.LogInformation($"{@event.GetType().Name} with id {@event.Id} was received in {className}");
    }
}