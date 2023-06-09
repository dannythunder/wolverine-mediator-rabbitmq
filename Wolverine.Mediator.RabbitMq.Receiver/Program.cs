using Serilog;
using Wolverine;
using Wolverine.Mediator.RabbitMq.Common;
using Wolverine.Mediator.RabbitMq.Receiver.Helpers;
using Wolverine.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Wolverine
builder.Host.UseWolverine(opts =>
{
    var queueName = "Receiver";
    var connectionString = builder.Configuration.GetConnectionString("MessageBroker");

    opts.UseRabbitMq(new Uri(connectionString))
        .AddQueueBindingsForMessages(queueName, MessagebrokerMessagesHelper.SERVICE_COMMANDS)  // Messages for this service, empty for now
        .AddQueueBindingsForMessages(queueName, MessagebrokerMessagesHelper.EXTERNAL_EVENTS)   // Events from other services
        .AutoProvision();

    opts.ListenToRabbitQueue(queueName, q =>
    {
        q.IsDurable = true;
    });
});

// Logger
builder.Host.UseSerilog((context, config) =>
    config.ReadFrom.Configuration(context.Configuration));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
//return await app.RunOaktonCommands(args);