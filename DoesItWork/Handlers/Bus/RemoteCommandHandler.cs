using DoesItWork.Handlers.Bus.Events;
using System.Reflection.Metadata;

namespace DoesItWork.Handlers.Bus;

public class RemoteCommandHandler
{
    public void Handle(RemoteEvent @event)
    {
        Console.WriteLine($"Remote event with id {@event.Id} was received in RemoteCommandHandler");
    }
}