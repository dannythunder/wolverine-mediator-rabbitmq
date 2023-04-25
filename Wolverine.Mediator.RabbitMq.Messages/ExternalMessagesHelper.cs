using System.Reflection;
using Wolverine.Mediator.RabbitMq.Messages.Bus.Command;
using Wolverine.Mediator.RabbitMq.Messages.Bus.Events;

namespace Wolverine.Mediator.RabbitMq.Messages;

public class ExternalMessagesHelper
{
    public static string NAMESPACE => typeof(ExternalMessagesHelper).Namespace;
    public static Type TYPE => typeof(ExternalMessagesHelper);
    public static Assembly ASSEMBLY => typeof(ExternalMessagesHelper).Assembly;

    // THIS IS JUST FOR LAZYNESS, SHOULD BE DONE "SERVER SIDE" FOR CUSTOM NEEDS
    public static Type[] MESSAGE_TYPES => new[]
    {
        typeof(RemoteCommand),
        typeof(RemoteEvent),
    };
}