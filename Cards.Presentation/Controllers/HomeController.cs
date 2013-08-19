using System.Web.Mvc;
using Cards.Lobby.Components;
using Cards.Lobby.GameComponents;
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
                return View(game.Result);
            }
            return View("Error");
        }
    }
}