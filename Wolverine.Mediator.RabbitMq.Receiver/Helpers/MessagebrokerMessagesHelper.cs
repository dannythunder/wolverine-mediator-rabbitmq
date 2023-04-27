using Wolverine.Mediator.RabbitMq.Sender.Messages.Bus.Events;

namespace Wolverine.Mediator.RabbitMq.Receiver.Helpers;

public class MessagebrokerMessagesHelper
{
    public static Type[] EXTERNAL_EVENTS => new[]
    {
        // From service Wolverine.Mediator.RabbitMq.Sender
        typeof(SenderRemoteEvent),
        
        // From a second service
        
        // From a third service
    };

    public static Type[] SERVICE_COMMANDS { get; } = new Type[0];
}