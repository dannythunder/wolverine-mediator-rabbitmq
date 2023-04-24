using Wolverine.Mediator.RabbitMq.Handlers.Mediator.Events;

namespace Wolverine.Mediator.RabbitMq.Handlers.Mediator;

public class LocalBroadcast2Handler
{
    public void Handle(LocalEvent @event, ILogger<LocalBroadcast2Handler> logger)
    {
        logger.LogInformation($"Local event with id {@event.Id} was received in LocalBroadcast_2_Handler");
    }
}