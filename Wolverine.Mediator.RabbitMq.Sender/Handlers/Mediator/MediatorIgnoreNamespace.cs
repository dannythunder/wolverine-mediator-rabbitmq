using System.Reflection;

namespace Wolverine.Mediator.RabbitMq.Sender.Handlers.Mediator;

public class MediatorIgnoreNamespace
{
    public static string NAMESPACE => typeof(MediatorIgnoreNamespace).Namespace;
    public static Type TYPE => typeof(MediatorIgnoreNamespace);
    public static Assembly ASSEMBLY => typeof(MediatorIgnoreNamespace).Assembly;
}