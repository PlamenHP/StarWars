
namespace StarWars3.Web.Areas.Admin.Controllers
{
    using StartWars3.Data.UnitOfWork;
    using System.Web.Mvc;

    public class HomeController : AdminController
    {
        public HomeController(IStarWars3DB data)
            : base(data)
        {
        }
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}