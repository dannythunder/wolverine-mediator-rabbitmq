using Wolverine.Mediator.RabbitMq.Sender.Messages.Bus.Events;
using Wolverine.Mediator.RabbitMq.ReceiverDual.Messages.Bus.Command;

namespace Wolverine.Mediator.RabbitMq.ReceiverDual.Helpers;

public class MessagebrokerMessagesHelper
{
    public static Type[] EXTERNAL_EVENTS => new[]
    {
        // From service Wolverine.Mediator.RabbitMq.Sender
        typeof(RemoteEvent),
        
        // From a second service
        
        // From a third service
    };
    
    public static Type[] SERVICE_COMMANDS => new[]
    {
        // From service Wolverine.Mediator.RabbitMq.Sender
        typeof(RemoteCommand)
        
        // From a second service
        
        // From a third service
    };
}