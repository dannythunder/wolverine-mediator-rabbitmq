using Wolverine.Mediator.RabbitMq.Handlers.Mediator.Commands;

namespace Wolverine.Mediator.RabbitMq.Handlers.Mediator;

public class LocalCommandConsumer
{
    public void Consume(LocalCommand command, ILogger<LocalCommandConsumer> logger)
    {
        var className = GetType().Name;
        logger.LogInformation($"{command.GetType().Name} with id {command.Id} was received in {className}");
    }
}