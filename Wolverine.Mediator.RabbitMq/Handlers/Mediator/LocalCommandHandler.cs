using Wolverine.Mediator.RabbitMq.Handlers.Mediator.Commands;

namespace Wolverine.Mediator.RabbitMq.Handlers.Mediator;

public class LocalCommandHandler
{
    public void Handle(LocalCommand command, ILogger<LocalCommandHandler> logger)
    {
        logger.LogInformation($"Local command with id {command.Id} was received in LocalCommandHandler");
    }
}