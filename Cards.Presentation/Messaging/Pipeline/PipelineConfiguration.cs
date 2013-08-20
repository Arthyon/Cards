using Cards.Presentation.Messaging.Messages;
using Cards.Presentation.Messaging.Pipeline.Steps.GameCreated;

namespace Cards.Presentation.Messaging.Pipeline
{
    public interface IPipelineConfiguration
    {
        Pipeline<GameCreatedMessage> GameCreatedPipeline { get; }
        Pipeline<PlayerJoinedMessage> PlayerJoinsGamePipeline { get; }
    }

    public class PipelineConfiguration : IPipelineConfiguration
    {
        public PipelineConfiguration()
        {
            GameCreatedPipeline = new Pipeline<GameCreatedMessage>()
                .Register(msg => new AddGameToLobby(msg))
                .Register(msg => new PlayerJoinsGame(msg))
                .Register(msg => new BroadcastGameCreated(msg));

            PlayerJoinsGamePipeline = new Pipeline<PlayerJoinedMessage>();
        }

        public Pipeline<GameCreatedMessage> GameCreatedPipeline { get; private set; }

        public Pipeline<PlayerJoinedMessage> PlayerJoinsGamePipeline { get; private set; }
    }
}