using Cards.Lobby.GameComponents;
using Cards.Presentation.Core;
using Cards.Presentation.Messaging.Messages;
using Cards.Presentation.Messaging.Pipeline.Events;

namespace Cards.Presentation.Messaging.Pipeline.Steps.GameCreated
{
    public class PlayerJoinsGame
    {
        public PlayerJoinsGame(PlayerJoinedGameEvent msg)
        {
            Process(msg.Game.Result);
        }

        public PlayerJoinsGame(GameCreatedEvent msg)
        {
            Process(msg.CreatedGame);
        }

        private void Process(Game game)
        {
            Locate<IUserContext>.Instance.JoinGame(game.Id);
        }
    }
}