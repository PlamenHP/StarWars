using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StarWars3.Data;
using StarWars3.Models;
using StartWars3.Data.UnitOfWork;
using StarWars3.Web.Areas.Admin.ViewModels;

namespace StarWars3.Web.Areas.Admin.Controllers
{
    public class PlanetTemplatesController : AdminController
    {
        public PlanetTemplatesController(IStarWars3DB data)
            : base(data)
        {
        }

        // GET: Admin/PlanetTemplates
        public ActionResult Index()
        {
            var planetTemplates = this.Data.PlanetTemplates
                    .All()
                    .OrderBy(x => x.Name)
                    .ToList();

            var planetTemplateViewModel = Mapper.Map<IEnumerable<PlanetTemplateViewModel>>(planetTemplates);

            return View(planetTemplateViewModel);
        }

        // GET: Admin/PlanetTemplates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var planetTemplate = Data.PlanetTemplates.GetById(id);
            if (planetTemplate == null)
            {
                return HttpNotFound();
            }
            var planetTemplateViewModel = this.Mapper.Map<PlanetTemplateViewModel>(planetTemplate);
            return View(planetTemplateViewModel);
        }

        // GET: Admin/PlanetTemplates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PlanetTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlanetTemplateViewModel planetTemplateViewModel)
        {
            if (ModelState.IsValid)
            {
                var planetTemplate = Mapper.Map<PlanetTemplate>(planetTemplateViewModel);
                Data.PlanetTemplates.Add(planetTemplate);
                Data.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(planetTemplateViewModel);
        }

        // GET: Admin/PlanetTemplates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanetTemplate planetTemplate = Data.PlanetTemplates.GetById(id);
            if (planetTemplate == null)
            {
                return HttpNotFound();
            }

            var planetTemplateViewModel = this.Mapper.Map<PlanetTemplateViewModel>(planetTemplate);
            if (!TempData.ContainsKey("image"))
            {
                TempData.Add("image", planetTemplate.Image);
            }
            else
            {
                TempData["image"] = planetTemplate.Image;
            }

            ViewBag.ImageId = new SelectList(this.Data.PlanetTemplates.All(), "Id", "Name", planetTemplateViewModel.Id);
            return View(planetTemplateViewModel);
        }

        // POST: Admin/PlanetTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PlanetTemplateViewModel planetTemplateViewModel)
        {
            if (ModelState.IsValid)
            {
                PlanetTemplate planetTemplate = this.Mapper.Map<PlanetTemplate>(planetTemplateViewModel);
                if (planetTemplateViewModel.ImageFromView == null)
                {
                    planetTemplate.Image = (byte[])TempData["image"];
                }

                if (TempData.ContainsKey("image"))
                {
                    TempData.Remove("image");
                }

                this.Data.PlanetTemplates.Update(planetTemplate);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ImageId = new SelectList(this.Data.PlanetTemplates.All(), "Id", "Name", planetTemplateViewModel.Id);
            return View(planetTemplateViewModel);
        }

        // GET: Admin/PlanetTemplates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanetTemplate planetTemplate = Data.PlanetTemplates.GetById(id);
            if (planetTemplate == null)
            {
                return HttpNotFound();
            }
            var planetTemplateViewModel = this.Mapper.Map<PlanetTemplateViewModel>(planetTemplate);
            return View(planetTemplateViewModel);
        }

        // POST: Admin/PlanetTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlanetTemplate planetTemplate = Data.PlanetTemplates.GetById(id);
            Data.PlanetTemplates.Delete(planetTemplate);
            Data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
