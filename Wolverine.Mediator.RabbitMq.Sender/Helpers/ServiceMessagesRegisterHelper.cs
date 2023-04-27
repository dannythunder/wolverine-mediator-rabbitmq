using Wolverine.Mediator.RabbitMq.ReceiverDual.Messages;
using Wolverine.Mediator.RabbitMq.Sender.Messages.Bus.Events;
using Wolverine.Mediator.RabbitMq.ReceiverDual.Messages.Bus.Command;
using Wolverine.RabbitMQ;

namespace Wolverine.Mediator.RabbitMq.Sender.Helpers;

public static class ServiceMessagesRegisterHelper
{
    // Events published from this service
    public static WolverineOptions AddEventForPublishing(this WolverineOptions opts)
    {
        
        opts.PublishMessage<SenderRemoteEvent>().ToRabbitExchange(typeof(SenderRemoteEvent).Name); // Event
        
        return opts;
    }
    
    // Commands to other services published from this service
    public static WolverineOptions AddCommandsForPublishing(this WolverineOptions opts)
    {
        // Send to specific exchange, can this be done in another more dynamic way?
        opts.PublishMessage<ReceiverDualRemoteCommand>().ToRabbitExchange(ReceiverDualQueueName.EXCHANGE_NAME);
        
        return opts;
    }
}