namespace SignalR;
/// <summary>
/// This Interface allows for the implementation of users own methods in ChatHub.cs (which extends the class of Hub by SignalR) 
/// </summary>
public interface IChatClient
{
    
    // The Task  represents a single operation that does not return a value and that usually executes asynchronously. 
    Task ReceiveMessage(string message);

}