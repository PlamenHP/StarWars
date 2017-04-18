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

namespace StarWars3.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UnitsController : Controller
    {
        private StarWars3Context db = new StarWars3Context();

        // GET: Admin/Units
        public ActionResult Index()
        {
            var units = db.Units.Include(u => u.Image).Include(u => u.Location).Include(u => u.Player).Include(u => u.Price).Include(u => u.UnitLevel);
            return View(units.ToList());
        }

        // GET: Admin/Units/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // GET: Admin/Units/Create
        public ActionResult Create()
        {
            ViewBag.ImageId = new SelectList(db.Images, "Id", "Name");
            ViewBag.LocationId = new SelectList(db.Cells, "Id", "Id");
            ViewBag.PlayerId = new SelectList(db.Players, "Id", "AspNetId");
            ViewBag.PriceId = new SelectList(db.Prices, "Id", "Name");
            ViewBag.UnitLevelId = new SelectList(db.UnitLevels, "Id", "Name");
            return View();
        }

        // POST: Admin/Units/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Type,WarFactotyRequiredLevel,ImageId,PriceId,PlayerId,UnitLevelId,LocationId")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Units.Add(unit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ImageId = new SelectList(db.Images, "Id", "Name", unit.ImageId);
            ViewBag.LocationId = new SelectList(db.Cells, "Id", "Id", unit.LocationId);
            ViewBag.PlayerId = new SelectList(db.Players, "Id", "AspNetId", unit.PlayerId);
            ViewBag.PriceId = new SelectList(db.Prices, "Id", "Name", unit.PriceId);
            ViewBag.UnitLevelId = new SelectList(db.UnitLevels, "Id", "Name", unit.UnitLevelId);
            return View(unit);
        }

        // GET: Admin/Units/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            ViewBag.ImageId = new SelectList(db.Images, "Id", "Name", unit.ImageId);
            ViewBag.LocationId = new SelectList(db.Cells, "Id", "Id", unit.LocationId);
            ViewBag.PlayerId = new SelectList(db.Players, "Id", "AspNetId", unit.PlayerId);
            ViewBag.PriceId = new SelectList(db.Prices, "Id", "Name", unit.PriceId);
            ViewBag.UnitLevelId = new SelectList(db.UnitLevels, "Id", "Name", unit.UnitLevelId);
            return View(unit);
        }

        // POST: Admin/Units/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Type,WarFactotyRequiredLevel,ImageId,PriceId,PlayerId,UnitLevelId,LocationId")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ImageId = new SelectList(db.Images, "Id", "Name", unit.ImageId);
            ViewBag.LocationId = new SelectList(db.Cells, "Id", "Id", unit.LocationId);
            ViewBag.PlayerId = new SelectList(db.Players, "Id", "AspNetId", unit.PlayerId);
            ViewBag.PriceId = new SelectList(db.Prices, "Id", "Name", unit.PriceId);
            ViewBag.UnitLevelId = new SelectList(db.UnitLevels, "Id", "Name", unit.UnitLevelId);
            return View(unit);
        }

        // GET: Admin/Units/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: Admin/Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Unit unit = db.Units.Find(id);
            db.Units.Remove(unit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
