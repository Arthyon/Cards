using System.Web.Mvc;
using Cards.Lobby.LobbyComponents;
using Cards.Presentation.Core;

namespace Cards.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var lobby = Locate<ILobby>.Instance;

            var games = lobby.GetGames();
            return View();
        }
    }
}
