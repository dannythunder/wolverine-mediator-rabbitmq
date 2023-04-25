using Wolverine.RabbitMQ;
using Wolverine.RabbitMQ.Internal;

namespace Wolverine.Mediator.RabbitMq.Common;

public static class AddCustomQueueStuff
{
    public static RabbitMqTransportExpression AddQueueBindings(this RabbitMqTransportExpression opts, params Type[] types)
    {

        
        foreach (var type in types)
        {
            opts.DeclareExchange(type.Name).BindExchange(type.Name)
                .ToQueue(type.Name, type.Name);
        }
        
        return opts;
    }
    
    public static WolverineOptions AddQueueListeners(this WolverineOptions opts, params Type[] types)
    {
        foreach (var type in types)
        {
            opts.ListenToRabbitQueue(type.Name, q =>
            {
                q.IsDurable = true;
            });
        }
        
        return opts;
    }
}