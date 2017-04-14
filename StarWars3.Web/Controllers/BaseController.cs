namespace StarWars3.Web.Controllers
{
    using AutoMapper;
    using Models;
    using StartWars3.Data.UnitOfWork;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    public abstract class BaseController : Controller
    {
        protected BaseController(IStarWars3DB data)
        {
            if (data == null)
            {
                throw new ArgumentException("An instance of IStoreDb is required to use this controller.", "data");
            }

            this.Data = data;
        }

        protected BaseController(IStarWars3DB data, ApplicationUser userProfile)
            : this(data)
        {
            if (userProfile == null)
            {
                throw new ArgumentException("An instance of ApplicationUser is required to use this controller.", "data");
            }

            this.UserProfile = userProfile;
        }

        protected IStarWars3DB Data { get; private set; }

        protected ApplicationUser UserProfile { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var userName = requestContext.HttpContext.User.Identity.Name;
                var user = this.Data.Users.All().FirstOrDefault(x => x.UserName == userName);
                this.UserProfile = user;
            }

            return base.BeginExecute(requestContext, callback, state);
        }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}