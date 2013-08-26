using Cards.Messaging.Pipeline;
using Cards.Presentation.Messaging.Pipeline.Events;
using Cards.Presentation.Messaging.Pipeline.Events.PlayerEvents;
using Cards.Presentation.Messaging.Pipeline.Steps.GameCreated;
using Cards.Presentation.Messaging.Pipeline.Steps.PlayerConnectedToHub;
using Cards.Presentation.Messaging.Pipeline.Steps.PlayerDisconnectedFromHub;
using Cards.Presentation.Messaging.Pipeline.Steps.PlayerJoinsGame;

namespace Cards.Presentation.Messaging.Pipeline
{
    public interface IPipelines
    {
        Pipeline<GameCreatedEvent> GameCreatedPipeline { get; }
        Pipeline<PlayerJoinedGameEvent> PlayerJoinsGamePipeline { get; }
        Pipeline<PlayerConnectedToHubEvent> PlayerConnectedToHub { get; } 
        Pipeline<PlayerDisconnectedFromHubEvent> PlayerDisconnectedFromHub { get; } 
    }

    public class PipelineConfiguration : IPipelines
    {
        public PipelineConfiguration()
        {
            GameCreatedPipeline = new Pipeline<GameCreatedEvent>()
                .Register(AddGameToLobbyStep.AddGameToLobby)
                .Register(PlayerJoinsGameStep.PlayerJoinsGame)
                .Register(BroadcastGameCreatedStep.BroadcastGameCreated);


            PlayerJoinsGamePipeline = new Pipeline<PlayerJoinedGameEvent>()
                .Register(DoesGameExistStep.DoesGameExist)
                .Register(AddPlayerToGameStep.AddPlayerToGame)
                .Register(BroadcastPlayerJoinedMessageStep.BroadcastPlayerJoinedMessage);


            PlayerConnectedToHub = new Pipeline<PlayerConnectedToHubEvent>()
                .Register(AddPlayerToCurrentPlayersStep.AddPlayerToCurrentPlayers)
                .Register(MarkPlayerAsOnlineStep.MarkPlayerAsOnline)
                .Register(AddConnectionIdToPlayerStep.AddConnectionIdToPlayer);

            PlayerDisconnectedFromHub = new Pipeline<PlayerDisconnectedFromHubEvent>()
                .Register(RemovePlayerFromCurrentPlayersStep.RemovePlayerFromCurrentPlayers)
                .Register(MarkPlayerAsOfflineStep.MarkPlayerAsOffline);
        }

        public Pipeline<GameCreatedEvent> GameCreatedPipeline { get; private set; }

        public Pipeline<PlayerJoinedGameEvent> PlayerJoinsGamePipeline { get; private set; }

        public Pipeline<PlayerConnectedToHubEvent> PlayerConnectedToHub { get; private set; }
        public Pipeline<PlayerDisconnectedFromHubEvent> PlayerDisconnectedFromHub { get; private set; } 
    }
}