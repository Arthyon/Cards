using System.Web.Mvc;
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
            var game = Get.CurrentPlayer.CurrentGame;
            if (game.IsSuccessful)
            {
                return View("Game", game.Result);
            }
            return View();
        }

        public ActionResult Game()
        {

            Maybe<Game> game = Get.CurrentPlayer.CurrentGame;
            if (game.IsSuccessful)
            {
                return View(game.Result);
            }
            return View("Error");
        }
    }
}