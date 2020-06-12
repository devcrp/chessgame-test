using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGame.Api.Hubs
{
    public class GameHub : Hub
    {
        public async Task RefreshGame()
        {
            await Clients.All.SendAsync("RefreshGame");
        }
    }
}
