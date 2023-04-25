using Wolverine.Mediator.RabbitMq.Handlers.Mediator.Events;

namespace Wolverine.Mediator.RabbitMq.Handlers.Mediator;

public class LocalBroadcast2Handler
{
    public void Handle(LocalEvent @event, ILogger<LocalBroadcast2Handler> logger)
    {
        var className = GetType().Name;
        logger.LogInformation($"{@event.GetType().Name} with id {@event.Id} was received in {className} Handle method");
    }
    
    // Handler can fetch events in several ways
    public void Consume(LocalEvent @event, ILogger<LocalBroadcast2Handler> logger)
    {
        var className = GetType().Name;
        logger.LogInformation($"{@event.GetType().Name} with id {@event.Id} was received  in {className} Consume method");
    }
}