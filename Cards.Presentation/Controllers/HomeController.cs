using System.Web.Mvc;
using Cards.Presentation.Core;
using Cards.Presentation.Lobby;

namespace Cards.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var lobby = Locate<ILobby>.Instance; 
            return View();
        }
    }
}
