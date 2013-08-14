using System.Threading;
using System.Web.Mvc;
using System.Web.Security;
using Cards.Lobby;
using Cards.Lobby.Components;
using Cards.Lobby.GameComponents;
using Cards.Lobby.User;
using Cards.Presentation.Core;

namespace Cards.Presentation.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Game()
        {
            Maybe<Game> game = Locate<IUserContextProvider>.Instance.UserContext.CurrentGame;
            if (game.IsSuccessful)
            {
                return View();
            }
            return View();
        }
    }
}