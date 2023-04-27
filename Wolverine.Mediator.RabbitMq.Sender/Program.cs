using Oakton;
using Serilog;
using Wolverine;
using Wolverine.Mediator.RabbitMq.Sender.Messages.Bus.Events;
using Wolverine.Mediator.RabbitMq.ReceiverDual.Messages.Bus.Command;
using Wolverine.Mediator.RabbitMq.Sender.Helpers;
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
        .AutoProvision();
    
    // Bind outgoing messages, could this be magically done if there is a lot of events/commands? 
    // Hiding in extensions to not bloat the setup
    
    // These are essatially:
    // opts.PublishMessage<MyMessage>().ToRabbitExchange(exchangeName: typeof(MyMessage).Name);
    opts.AddEventForPublishing();
    opts.AddCommandsForPublishing();

});

// Setup logger
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

//app.Run();
return await app.RunOaktonCommands(args);