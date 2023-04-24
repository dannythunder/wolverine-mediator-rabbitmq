using Wolverine.Mediator.RabbitMq.Handlers.Bus.Events;

namespace Wolverine.Mediator.RabbitMq.Handlers.Bus;

public class RemoteCommandHandler
{
    public void Handle(RemoteEvent @event, ILogger<RemoteCommandHandler> logger)
    {
        logger.LogInformation($"Remote event with id {@event.Id} was received in RemoteCommandHandler");
    }
}