using Serilog;
using Wolverine;
using Wolverine.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

// Wolverine
builder.Host.UseWolverine(opts =>
{
    var connectionString = builder.Configuration.GetConnectionString("MessageBroker");
    opts.UseRabbitMq(new Uri(connectionString))
        .UseConventionalRouting() // Should route message from message type name exchange, to queue with same name?
        .AutoProvision() // Creates all queues and stuff in RabbitMQ
        .PrefixIdentifiers("prefix2000"); // Prefixes queues. Duh.
    
        // How to specify that a certain message is internal mediator, and another is an external event via rabbit?
        // see handlers and messages in /Handlers/Bus and /Handlers/Mediator
});

// Logger
builder.Host.UseSerilog((context, config) =>
    config.ReadFrom.Configuration(context.Configuration));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Logger
app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();