using Cards.Lobby;
using Cards.Lobby.GameComponents;
using Cards.Presentation.Messaging.Pipeline.Events;

namespace Cards.Presentation.Messaging.Pipeline.Steps.GameCreated
{
    public class PlayerJoinsGameStep
    {
        public static bool PlayerJoinsGame(PlayerJoinedGameEvent msg)
        {
            return Process(msg.Game.Result, msg.Player);
        }



        public static bool PlayerJoinsGame(GameCreatedEvent msg)
        {
            return Process(msg.CreatedGame, msg.GameOwner);
        }

        private static bool Process(Game game, Player player)
        {
            var result = game.AddPlayer(player);
            if (result.IsSuccessful)
            {
                player.CurrentGame = game;

                return true;
            }
            return false;

        }
    }
}