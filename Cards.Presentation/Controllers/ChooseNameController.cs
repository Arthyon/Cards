using System.Web.Mvc;
using System.Web.Security;
using Cards.Lobby;
using Cards.Lobby.User;
using Cards.Presentation.Core;

namespace Cards.Presentation.Controllers
{
    public class ChooseNameController : Controller
    {
        //
        // GET: /ChooseName/

        public ActionResult Index(string returnUrl)
        {
            return View((object)returnUrl);
        }

        [HttpPost]
        public RedirectResult Login(string returnUrl, string userName)
        {
            var player = new Player(Session.SessionID, userName);
            Locate<IUserManager>.Instance.AddPlayer(player);

            FormsAuthentication.SetAuthCookie(Session.SessionID, false);

            return Redirect(returnUrl);
        }
    }
}
