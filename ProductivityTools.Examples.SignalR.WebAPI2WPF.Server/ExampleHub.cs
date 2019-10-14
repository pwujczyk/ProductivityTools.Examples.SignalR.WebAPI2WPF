using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductivityTools.Examples.SignalR.WebAPI2WPF.Server
{
    public class ExampleHub : Hub
    {
        public void Send(string text)
        {
            Clients.All.SendAsync("Send", text);
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine(Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
