using System.Collections.Generic;
using System.Web.Http;
using Cards.Lobby.GameComponents;
using Cards.Lobby.LobbyComponents;
using Cards.Presentation.Core;

namespace Cards.Presentation.WebAPI
{
    public class LobbyApiController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> GetAvailableGameTypes()
        {
            return new[] {"PlanningPoker"};
        }

        public IEnumerable<Game> GetAvailableGames()
        {
            var games = Locate<ILobby>.Instance.GetGames();
            return games;
        }
    }
}