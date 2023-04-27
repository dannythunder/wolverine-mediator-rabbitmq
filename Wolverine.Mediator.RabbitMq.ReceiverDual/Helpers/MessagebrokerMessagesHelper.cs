using Wolverine.Mediator.RabbitMq.Sender.Messages.Bus.Events;
using Wolverine.Mediator.RabbitMq.ReceiverDual.Messages.Bus.Command;

namespace Wolverine.Mediator.RabbitMq.ReceiverDual.Helpers;

public class MessagebrokerMessagesHelper
{
    public static Type[] EXTERNAL_EVENTS_TYPES => new[]
    {
        // From service Wolverine.Mediator.RabbitMq.Sender
        typeof(SenderRemoteEvent),
        
        // From a second service
        
        // From a third service
    };
    
    public static Type[] SERVICE_COMMANDS_TYPES => new[]
    {
        // From service Wolverine.Mediator.RabbitMq.Sender
        typeof(ReceiverDualRemoteCommand)
        
        // From a second service
        
        // From a third service
    };
}