using Cards.Lobby;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Cards.Presentation.Core
{
    public static class SignalRExtensions
    {
        public static dynamic Game(this IHubConnectionContext context, Player player)
        {
            var game = player.CurrentGame.Result;
            return context.Group(game.GroupName);
        }

        public static dynamic OthersInGame(this IHubConnectionContext context, Player player)
        {
            return context.Group(player.CurrentGame.Result.GroupName, player.ConnectionIds.ToArray());
        }



        
    }
}