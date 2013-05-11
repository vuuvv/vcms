using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vuuvv.web.Models;
using vuuvv.web.Models.ViewModel;

namespace vuuvv.web.Controllers
{
    public class AdminBannerImageController : AdminController
    {
        private VDB db = new VDB();
        private string title = "产品管理";

        //
        // GET: /AdminBannerImage/

        public ActionResult Index()
        {
            CreateFrame(title);
            var bannerimages = db.BannerImages.Include(b => b.Category).OrderBy(i => i.ProductCategoryId).ThenBy(i => i.Ordering) ;
            return View(bannerimages.ToList());
        }

        //
        // GET: /AdminBannerImage/Details/5

        public ActionResult Details(int id = 0)
        {
            BannerImage bannerimage = db.BannerImages.Find(id);
            if (bannerimage == null)
            {
                return HttpNotFound();
            }
            return View(bannerimage);
        }

        //
        // GET: /AdminBannerImage/Create

        public ActionResult Create()
        {
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories, "Id", "Name");
            CreateFrame(title);
            return View();
        }

        //
        // POST: /AdminBannerImage/Create

        [HttpPost]
        public ActionResult Create(BannerImage bannerimage)
        {
            if (ModelState.IsValid)
            {
                db.BannerImages.Add(bannerimage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories, "Id", "Name", bannerimage.ProductCategoryId);
            CreateFrame(title);
            return View(bannerimage);
        }

        //
        // GET: /AdminBannerImage/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BannerImage bannerimage = db.BannerImages.Find(id);
            if (bannerimage == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories, "Id", "Name", bannerimage.ProductCategoryId);
            CreateFrame(title);
            return View(bannerimage);
        }

        //
        // POST: /AdminBannerImage/Edit/5

        [HttpPost]
        public ActionResult Edit(BannerImage bannerimage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bannerimage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories, "Id", "Name", bannerimage.ProductCategoryId);
            return View(bannerimage);
        }

        //
        // GET: /AdminBannerImage/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BannerImage bannerimage = db.BannerImages.Find(id);
            if (bannerimage == null)
            {
                return HttpNotFound();
            }
            db.BannerImages.Remove(bannerimage);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }

        //
        // POST: /AdminBannerImage/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(List<int> ids)
        {
            var objs = db.BannerImages.Where(p => ids.Contains(p.Id));
            foreach (var obj in objs)
            {
                db.BannerImages.Remove(obj);
            }
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}