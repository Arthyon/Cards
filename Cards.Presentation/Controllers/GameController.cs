using System.Web.Mvc;

namespace Cards.Presentation.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}