
//namespace StarWars3.Web.Areas.Admin.Controllers
//{
//    using System.Data.Entity;
//    using System.Linq;
//    using System.Net;
//    using System.Web.Mvc;
//    using Data;
//    using Models;
//    using ViewModels;
//    using AutoMapper;
//    using Web.Controllers;
//    using StartWars3.Data.UnitOfWork;
//    using StartWars3.Data;
//    using System.Collections.Generic;

//    [Authorize(Roles = "Admin")]
//    public class ImagesController : BaseController
//    {
//        public ImagesController(IStarWars3DB data)
//            : base(data)
//        {
//        }


//        // GET: Admin/Images
//        public ActionResult Index()
//        {
//            var images = this.Data.Images
//                    .All()
//                    .OrderBy(x => x.Name)
//                    .ToList();

//            var imagesViewModel = Mapper.Map<IEnumerable<ImageViewModel>>(images);

//            return View(imagesViewModel);
//        }

//        // GET: Admin/Images/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Image image = Data.Images.GetById(id);
//            if (image == null)
//            {
//                return HttpNotFound();
//            }
//            var imageViewModel = this.Mapper.Map<ImageViewModel>(image);
//            return View(imageViewModel);
//        }

//        // GET: Admin/Images/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Admin/Images/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(ImageViewModel imageViewModel)
//        {
//            if (ModelState.IsValid)
//            {
//                var image = Mapper.Map<Image>(imageViewModel);
//                Data.Images.Add(image);
//                Data.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(imageViewModel);
//        }

//        // GET: Admin/Images/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Image image = Data.Images.GetById(id);
//            if (image == null)
//            {
//                return HttpNotFound();
//            }

//            var imageViewModel = this.Mapper.Map<ImageViewModel>(image);
//            if (!TempData.ContainsKey("image"))
//            {
//                TempData.Add("image", image.Container);
//            }
//            else
//            {
//                TempData["image"] = image.Container;
//            }

//            ViewBag.ImageId = new SelectList(this.Data.Images.All(), "Id", "Name", imageViewModel.Id);
//            return View(imageViewModel);
//        }

//        // POST: Admin/Images/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(ImageViewModel imageViewModel)
//        {
//            if (ModelState.IsValid)
//            {
//                Image imageDto = this.Mapper.Map<Image>(imageViewModel);
//                if (imageViewModel.ImageFromView == null)
//                {
//                    imageDto.Container = (byte[])TempData["image"];
//                }

//                if (TempData.ContainsKey("image"))
//                {
//                    TempData.Remove("image");
//                }

//                this.Data.Images.Update(imageDto);
//                this.Data.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.ImageId = new SelectList(this.Data.Images.All(), "Id", "Name", imageViewModel.Id);
//            return View(imageViewModel);
//        }

//        // GET: Admin/Images/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Image image = Data.Images.GetById(id);
//            if (image == null)
//            {
//                return HttpNotFound();
//            }

//            var imageViewModel = this.Mapper.Map<ImageViewModel>(image);
//            return View(imageViewModel);
//        }

//        // POST: Admin/Images/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Image image = Data.Images.GetById(id);
//            Data.Images.Delete(image);
//            Data.SaveChanges();
//            return RedirectToAction("Index");
//        }
//    }
//}
