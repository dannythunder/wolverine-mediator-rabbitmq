using Wolverine.RabbitMQ.Internal;

namespace Wolverine.Mediator.RabbitMq.Common;

public static class CustomQueueExtensions
{
    public static RabbitMqTransportExpression AddQueueBindings(this RabbitMqTransportExpression opts, string queueName, params Type[] types)
    {
        foreach (var type in types)
        {
            opts.DeclareExchange(type.Name).BindExchange(type.Name)
                .ToQueue(queueName, type.Name);
        }
        
        return opts;
    }
}