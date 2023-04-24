using Wolverine.Mediator.RabbitMq.Handlers.Mediator.Events;

namespace Wolverine.Mediator.RabbitMq.Handlers.Mediator;

public class LocalBroadcast1Handler
{
    public void Handle(LocalEvent @event, ILogger<LocalBroadcast1Handler> logger)
    {
        logger.LogInformation($"Local event with id {@event.Id} was received in LocalBroadcast_1_Handler");
    }
}