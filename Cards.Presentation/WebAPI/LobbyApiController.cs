using System.Collections.Generic;
using System.Web.Http;

namespace Cards.Presentation.WebAPI
{
    public class LobbyApiController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> GetAvailableGameTypes()
        {
            return new[] {"PlanningPoker"};
        }
    }
}