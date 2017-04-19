
namespace StarWars3.Web.Areas.Admin.Controllers
{
    using StartWars3.Data.UnitOfWork;
    using StarWars3.Web.Controllers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    // ADMIN AUTORIZATION
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        public AdminController(IStarWars3DB data)
            : base(data)
        {
        }
    }
}