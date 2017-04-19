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
    public class UnitTemplatesController : AdminController
    {
        public UnitTemplatesController(IStarWars3DB data)
            : base(data)
        {
        }

        // GET: Admin/UnitTemplates
        public ActionResult Index()
        {
            var unitTemplates = this.Data.UnitTemplates
                    .All()
                    .OrderBy(x => x.UnitType)
                    .ToList();

            var unitTemplateViewModel = Mapper.Map<IEnumerable<UnitTemplateViewModel>>(unitTemplates);

            return View(unitTemplateViewModel);
        }

        // GET: Admin/UnitTemplates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var unitTemplate = Data.UnitTemplates.GetById(id);
            if (unitTemplate == null)
            {
                return HttpNotFound();
            }
            var unitTemplateViewModel = this.Mapper.Map<UnitTemplateViewModel>(unitTemplate);
            return View(unitTemplateViewModel);
        }

        // GET: Admin/UnitTemplates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/UnitTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UnitTemplateViewModel unitTemplateViewModel)
        {
            if (ModelState.IsValid)
            {
                var unitTemplate = Mapper.Map<UnitTemplate>(unitTemplateViewModel);
                Data.UnitTemplates.Add(unitTemplate);
                Data.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unitTemplateViewModel);
        }

        // GET: Admin/UnitTemplates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnitTemplate unitTemplate = Data.UnitTemplates.GetById(id);
            if (unitTemplate == null)
            {
                return HttpNotFound();
            }

            var unitTemplateViewModel = this.Mapper.Map<UnitTemplateViewModel>(unitTemplate);
            if (!TempData.ContainsKey("image"))
            {
                TempData.Add("image", unitTemplate.Image);
            }
            else
            {
                TempData["image"] = unitTemplate.Image;
            }

            ViewBag.ImageId = new SelectList(this.Data.UnitTemplates.All(), "Id", "Name", unitTemplateViewModel.Id);
            return View(unitTemplateViewModel);
        }

        // POST: Admin/UnitTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UnitTemplateViewModel unitTemplateViewModel)
        {
            if (ModelState.IsValid)
            {
                UnitTemplate unitTemplate = this.Mapper.Map<UnitTemplate>(unitTemplateViewModel);
                if (unitTemplateViewModel.ImageFromView == null)
                {
                    unitTemplate.Image = (byte[])TempData["image"];
                }

                if (TempData.ContainsKey("image"))
                {
                    TempData.Remove("image");
                }

                this.Data.UnitTemplates.Update(unitTemplate);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ImageId = new SelectList(this.Data.UnitTemplates.All(), "Id", "Name", unitTemplateViewModel.Id);
            return View(unitTemplateViewModel);
        }

        // GET: Admin/UnitTemplates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnitTemplate unitTemplate = Data.UnitTemplates.GetById(id);
            if (unitTemplate == null)
            {
                return HttpNotFound();
            }
            var unitTemplateViewModel = this.Mapper.Map<UnitTemplateViewModel>(unitTemplate);
            return View(unitTemplateViewModel);
        }

        // POST: Admin/UnitTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UnitTemplate unitTemplate = Data.UnitTemplates.GetById(id);
            Data.UnitTemplates.Delete(unitTemplate);
            Data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
