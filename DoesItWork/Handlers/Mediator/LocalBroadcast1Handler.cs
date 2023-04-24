using DoesItWork.Handlers.Mediator.Events;

namespace DoesItWork.Handlers.Mediator;

public class LocalBroadcast1Handler
{
    public void Handle(LocalEvent @event, ILogger<LocalBroadcast1Handler> logger)
    {
        logger.LogInformation($"Local event with id {@event.Id} was received in LocalBroadcast_1_Handler");
    }
}