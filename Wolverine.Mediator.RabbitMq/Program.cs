using Serilog;
using Wolverine;
using Wolverine.Mediator.RabbitMq;
using Wolverine.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Wolverine
builder.Host.UseWolverine(opts =>
{
    // This makes messages in said assembly being sent locally, does not stop rabbitmq creating queues
    opts.Publish().MessagesFromAssembly(AssemblyInformation.ASSEMBLY).Locally();
    
    var connectionString = builder.Configuration.GetConnectionString("MessageBroker");
    opts.UseRabbitMq(new Uri(connectionString))
        .AutoProvision()
        .UseConventionalRouting();
        //.PrefixIdentifiers("sender"); // Prefixes queues. Duh.; But also fore exchanges, why? 

    
    // I THINK code above solves most of this:
    
    // How to specify that a certain message / namespace is an internal mediator, and another is an external event via rabbit?
    // Is it still possible to use the auto discovery thingy when using both?
    // see handlers and messages in /Handlers/Bus and /Handlers/Mediator

    // As for now, everything gets set up in rabbitmq.
    // This is not the desired state
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
app.Run();