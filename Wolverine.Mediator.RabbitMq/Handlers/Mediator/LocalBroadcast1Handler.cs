using Wolverine.Mediator.RabbitMq.Handlers.Mediator.Events;

namespace Wolverine.Mediator.RabbitMq.Handlers.Mediator;

public class LocalBroadcast1Handler
{
    public void Handle(LocalEvent @event, ILogger<LocalBroadcast1Handler> logger)
    {
        var className = GetType().Name;
        logger.LogInformation($"{@event.GetType().Name} with id {@event.Id} was received in {className}");
    }
}