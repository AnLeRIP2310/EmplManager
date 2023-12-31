﻿using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;


namespace SignalRChat.Hubs
{
   
    public class ChatHub : Hub
    {
        public async Task SendMessage( string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",  message);
        }
        public async Task MessageDeleted(int mess_id)
        {
            await Clients.All.SendAsync("MessageDeleted", mess_id);
        }
        public async Task UpdateReaction(string json)
        {
            await Clients.All.SendAsync("UpdateReaction",json);
        }

        public async Task MessageEdited(string json)
        {
            await Clients.All.SendAsync("MessageEdited", json);
        }
    }
}