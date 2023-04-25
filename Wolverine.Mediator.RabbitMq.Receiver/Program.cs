using Serilog;
using Wolverine;
using Wolverine.Mediator.RabbitMq.Common;
using Wolverine.Mediator.RabbitMq.Messages;
using Wolverine.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Wolverine
builder.Host.UseWolverine(opts =>
{ 
    var connectionString = builder.Configuration.GetConnectionString("MessageBroker");

    opts.UseRabbitMq(new Uri(connectionString))
        .AddQueueBindings(ExternalMessagesHelper.MESSAGE_TYPES)
        .AutoProvision();

    opts.AddQueueListeners(ExternalMessagesHelper.MESSAGE_TYPES);
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