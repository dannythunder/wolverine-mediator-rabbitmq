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
        opts.PublishMessage<RemoteEvent>().ToRabbitExchange(typeof(RemoteEvent).Name); // Event
        
        return opts;
    }
    
    // Commands to other services published from this service
    public static WolverineOptions AddCommandsForPublishing(this WolverineOptions opts)
    {
        opts.PublishMessage<RemoteCommand>().ToRabbitExchange(ReceiverDualQueueName.EXCHANGE_NAME, ex => ex.BindQueue(ReceiverDualQueueName.QUEUE_NAME));
        
        return opts;
    }
}