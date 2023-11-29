using Microsoft.AspNetCore.SignalR;
using SignalR;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//Adds a RouteEndpoint to the IEndpointRouteBuilder that matches HTTP POST requests for the specified pattern.
app.MapPost("Broadcast",async (string message, IHubContext<ChatHub, IChatClient> context) =>
{
    //Insures ALL clients receive the message
    await context.Clients.All.ReceiveMessage(message);
    
    return Results.NoContent();
});
app.UseHttpsRedirection();

//Maps incoming requests with the specified path to the specified Hub type
app.MapHub<ChatHub>("chat-hub");
app.Run();