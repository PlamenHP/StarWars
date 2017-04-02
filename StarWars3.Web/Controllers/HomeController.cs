
namespace StarWars3.Web.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("Game");
            }

            return View();
        }

        public ActionResult Game()
        {
            return View();
        }
    }
}