using Wolverine.Mediator.RabbitMq.Handlers.Mediator.Commands;

namespace Wolverine.Mediator.RabbitMq.Handlers.Mediator;

public class LocalCommandHandler
{
    public void Handle(LocalCommand command, ILogger<LocalCommandHandler> logger)
    {
        var className = GetType().Name;
        logger.LogInformation($"{command.GetType().Name} with id {command.Id} was received in {className}");
    }
}