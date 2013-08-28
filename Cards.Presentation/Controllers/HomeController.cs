using System.Web.Mvc;
using Cards.Presentation.Core;

namespace Cards.Presentation.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var game = Get.CurrentPlayer.CurrentGame;
            return game.IsSuccessful ? View("Game", game.Result) : View();
        }

        public ActionResult Game()
        {
            var game = Get.CurrentPlayer.CurrentGame;
            return game.IsSuccessful ? View(game.Result) : View("Error");
        }
    }
}