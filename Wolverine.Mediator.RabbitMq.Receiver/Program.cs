using Serilog;
using Wolverine;
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
        .AutoProvision()
        .UseConventionalRouting();
        //.PrefixIdentifiers("receiver");
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