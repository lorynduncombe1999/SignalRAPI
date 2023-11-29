//This class extends Hub(From SignalR)
//Hub allows for Clients to connect with server and for server to send messages to client(Bidirectional)
//This is demonstrated through postman
namespace SignalR;
using Microsoft.AspNetCore.SignalR;
public class ChatHub:Hub<IChatClient>
{

    public override async Task OnConnectedAsync()
    {
        //Send Message to clients when they are connected
        await Clients.All.ReceiveMessage($"{Context.ConnectionId} has joined");

    }

    public async Task SendMessage(string message)
    {
        //Sends message to clients 
        await Clients.All.ReceiveMessage( $"{Context.ConnectionId},{message}");
    }
}
