
namespace StarWars3.Web.Controllers
{
    using System.Web.Mvc;
    using StartWars3.Data.UnitOfWork;

    public class HomeController : BaseController
    {
        public HomeController(IStarWars3DB data) : base(data)
        {
        }

        public ActionResult Index()
        {
            bool isAdmin = this.User.IsInRole("Admin");
            if (isAdmin)
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Game");
            }

            return View();
        }

        public ActionResult Game()
        {
            return View();
        }
    }
}