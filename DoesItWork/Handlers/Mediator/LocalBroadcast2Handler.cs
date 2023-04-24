using DoesItWork.Handlers.Mediator.Events;

namespace DoesItWork.Handlers.Mediator;

public class LocalBroadcast2Handler
{
    public void Handle(LocalEvent @event)
    {
        Console.WriteLine($"Local event with id {@event.Id} was received in LocalBroadcast_2_Handler");
    }
}