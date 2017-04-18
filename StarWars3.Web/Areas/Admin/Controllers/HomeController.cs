
namespace StarWars3.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}