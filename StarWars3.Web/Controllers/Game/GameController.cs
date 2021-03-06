﻿
namespace StarWars3.Web.Controllers.Game
{
    using Microsoft.AspNet.Identity;
    using Services.Game;
    using System.Web.Mvc;
    using ViewModels.Game;
    using StartWars3.Data.UnitOfWork;
    using Services.ServicesDTO;
    using System;

    public class GameController : BaseController
    {
        public GameController(IStarWars3DB data) : base(data)
        {
        }

        public ActionResult Index()
        {

            int playerId = InitialisePlayer.Initialise(User.Identity.GetUserId(), Data);

            return RedirectToAction("LoadGame",new {playerId});
        }

        // GET: Planet
        public ActionResult LoadGame(int? playerId)
        {
            //if (playerId == null)
            //{
            //    throw new ArgumentException("ShowGame: PlayerId cannot be null");
            //}

            PlayerId pId = new PlayerId() { Id = playerId.ToString() };
            return View(pId);
        }
    }
}