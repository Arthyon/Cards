using Cards.Lobby.GameComponents;
using Cards.Presentation.Core;
using Cards.Presentation.Messaging.Messages;

namespace Cards.Presentation.Messaging.Pipeline.Steps.GameCreated
{
    public class PlayerJoinsGame
    {
        public PlayerJoinsGame(PlayerJoinedMessage msg)
        {
            Process(msg.Game);
        }

        public PlayerJoinsGame(GameCreatedMessage msg)
        {
            Process(msg.CreatedGame);
        }

        private void Process(Game game)
        {
            Locate<IUserContext>.Instance.JoinGame(game.Id);
        }
    }
}