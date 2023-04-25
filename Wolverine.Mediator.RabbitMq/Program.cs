using Oakton;
using Serilog;
using Wolverine;
using Wolverine.Mediator.RabbitMq;
using Wolverine.Mediator.RabbitMq.Handlers.Mediator.Commands;
using Wolverine.Mediator.RabbitMq.Handlers.Mediator.Events;
using Wolverine.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Wolverine
builder.Host.UseWolverine(opts =>
{
    opts.Publish().MessagesFromAssembly(AssemblyInformation.ASSEMBLY).Locally();
    
    var connectionString = builder.Configuration.GetConnectionString("MessageBroker");
    
    opts.UseRabbitMq(new Uri(connectionString))
        .AutoProvision()
        .UseConventionalRouting(x => x
            .ExcludeTypes(type => type == typeof(LocalEvent))
            .ExcludeTypes(type => type == typeof(CrashCommand))
            .ExcludeTypes(type => type == typeof(LocalCommand))
        );
});

// Logger
builder.Host.UseSerilog((context, config) =>
    config.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Logger
app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

return await app.RunOaktonCommands(args);