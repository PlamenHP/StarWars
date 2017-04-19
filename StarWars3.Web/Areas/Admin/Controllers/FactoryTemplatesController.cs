using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using StarWars3.Data;
using StarWars3.Models;
using StartWars3.Data.UnitOfWork;
using System.Collections.Generic;
using StarWars3.Web.Areas.Admin.ViewModels;

namespace StarWars3.Web.Areas.Admin.Controllers
{
    public class FactoryTemplatesController : AdminController
    {
        public FactoryTemplatesController(IStarWars3DB data)
            : base(data)
        {
        }

        // GET: Admin/FactoryTemplates
        public ActionResult Index()
        {
            var factoryTemplates = this.Data.FactoryTemplates
                    .All()
                    .OrderBy(x => x.FactoryType)
                    .ToList();

            var factoryTemplateViewModel = Mapper.Map<IEnumerable<FactoryTemplateViewModel>>(factoryTemplates);

            return View(factoryTemplateViewModel);
        }

        // GET: Admin/FactoryTemplates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var factoryTemplate = Data.FactoryTemplates.GetById(id);
            if (factoryTemplate == null)
            {
                return HttpNotFound();
            }
            var factoryTemplateViewModel = this.Mapper.Map<FactoryTemplateViewModel>(factoryTemplate);
            return View(factoryTemplateViewModel);
        }

        // GET: Admin/FactoryTemplates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/FactoryTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FactoryTemplateViewModel factoryTemplateViewModel)
        {
            if (ModelState.IsValid)
            {
                var factoryTemplate = Mapper.Map<FactoryTemplate>(factoryTemplateViewModel);
                Data.FactoryTemplates.Add(factoryTemplate);
                Data.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(factoryTemplateViewModel);
        }

        // GET: Admin/FactoryTemplates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FactoryTemplate factoryTemplate = Data.FactoryTemplates.GetById(id);
            if (factoryTemplate == null)
            {
                return HttpNotFound();
            }

            var factoryTemplateViewModel = this.Mapper.Map<FactoryTemplateViewModel>(factoryTemplate);
            if (!TempData.ContainsKey("image"))
            {
                TempData.Add("image", factoryTemplate.Image);
            }
            else
            {
                TempData["image"] = factoryTemplate.Image;
            }

            ViewBag.ImageId = new SelectList(this.Data.FactoryTemplates.All(), "Id", "Name", factoryTemplateViewModel.Id);
            return View(factoryTemplateViewModel);
        }

        // POST: Admin/FactoryTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FactoryTemplateViewModel factoryTemplateViewModel)
        {
            if (ModelState.IsValid)
            {
                FactoryTemplate factoryTemplate = this.Mapper.Map<FactoryTemplate>(factoryTemplateViewModel);
                if (factoryTemplateViewModel.ImageFromView == null)
                {
                    factoryTemplate.Image = (byte[])TempData["image"];
                }

                if (TempData.ContainsKey("image"))
                {
                    TempData.Remove("image");
                }

                this.Data.FactoryTemplates.Update(factoryTemplate);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ImageId = new SelectList(this.Data.FactoryTemplates.All(), "Id", "Name", factoryTemplateViewModel.Id);
            return View(factoryTemplateViewModel);
        }

        // GET: Admin/FactoryTemplates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FactoryTemplate factoryTemplate = Data.FactoryTemplates.GetById(id);
            if (factoryTemplate == null)
            {
                return HttpNotFound();
            }
            var factoryTemplateViewModel = this.Mapper.Map<FactoryTemplateViewModel>(factoryTemplate);
            return View(factoryTemplateViewModel);
        }

        // POST: Admin/FactoryTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FactoryTemplate factoryTemplate = Data.FactoryTemplates.GetById(id);
            Data.FactoryTemplates.Delete(factoryTemplate);
            Data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
