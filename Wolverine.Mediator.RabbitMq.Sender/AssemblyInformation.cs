using System.Reflection;

namespace Wolverine.Mediator.RabbitMq.Sender;

public class AssemblyInformation
{
    public static Assembly ASSEMBLY => typeof(AssemblyInformation).Assembly;
}