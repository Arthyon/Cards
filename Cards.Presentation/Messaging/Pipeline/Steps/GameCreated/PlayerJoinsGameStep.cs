using Cards.Lobby;
using Cards.Lobby.GameComponents;
using Cards.Lobby.User;
using Cards.Presentation.Core;
using Cards.Presentation.Messaging.Messages;
using Cards.Presentation.Messaging.Pipeline.Events;

namespace Cards.Presentation.Messaging.Pipeline.Steps.GameCreated
{
    public class PlayerJoinsGameStep
    {
        public static void PlayerJoinsGame(PlayerJoinedGameEvent msg)
        {
            Process(msg.Game.Result, msg.Player);
        }



        public static void PlayerJoinsGame(GameCreatedEvent msg)
        {
            Process(msg.CreatedGame, msg.GameOwner);
        }

        private static void Process(Game game, Player player)
        {
            player.CurrentGame = game;
            game.AddPlayer(player);
        }
    }
}