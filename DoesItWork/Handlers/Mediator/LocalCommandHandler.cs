using DoesItWork.Handlers.Mediator.Commands;

namespace DoesItWork.Handlers.Mediator;

public class LocalCommandHandler
{
    public void Handle(LocalCommand command)
    {
        Console.WriteLine($"Local command with id {command.Id} was received in LocalCommandHandler");
    }
}