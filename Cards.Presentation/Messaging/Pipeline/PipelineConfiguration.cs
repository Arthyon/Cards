using Cards.Lobby;
using Cards.Presentation.Messaging.Aspects;
using Cards.Presentation.Messaging.Messages;
using Cards.Presentation.Messaging.Pipeline.Events;
using Cards.Presentation.Messaging.Pipeline.Steps.GameCreated;
using Cards.Presentation.Messaging.Pipeline.Steps.PlayerJoinsGame;

namespace Cards.Presentation.Messaging.Pipeline
{
    public interface IPipelines
    {
        Pipeline<GameCreatedEvent> GameCreatedPipeline { get; }
        Pipeline<PlayerJoinedGameEvent> PlayerJoinsGamePipeline { get; }
    }

    public class PipelineConfiguration : IPipelines
    {
        public PipelineConfiguration()
        {
            GameCreatedPipeline = new Pipeline<GameCreatedEvent>()
                .Register(ev => new AddGameToLobby(ev))
                .Register(ev => new PlayerJoinsGame(ev))
                .Register(ev => new BroadcastGameCreated(ev));


            PlayerJoinsGamePipeline = new Pipeline<PlayerJoinedGameEvent>()
                .Register(ev => new DoesGameExist(ev))
                .Register(ev => new AddPlayerToGame(ev))
                .Register(ev => new BroadcastPlayerJoinedMessage(ev));
        }

        public Pipeline<GameCreatedEvent> GameCreatedPipeline { get; private set; }

        public Pipeline<PlayerJoinedGameEvent> PlayerJoinsGamePipeline { get; private set; }
    }
}