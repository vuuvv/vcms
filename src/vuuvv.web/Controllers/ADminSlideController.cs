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
    public class AdminSlideController : AdminController
    {
        private VDB db = new VDB();
        private string title = "首页幻灯片";

        //
        // GET: /AdminBannerImage/

        public ActionResult Index()
        {
            CreateFrame(title);
            var slides = db.Slides.OrderBy(i => i.Ordering);
            return View(slides.ToList());
        }

        //
        // GET: /AdminBannerImage/Details/5

        public ActionResult Details(int id = 0)
        {
            Slide slides = db.Slides.Find(id);
            if (slides == null)
            {
                return HttpNotFound();
            }
            return View(slides);
        }

        //
        // GET: /AdminBannerImage/Create

        public ActionResult Create()
        {
            CreateFrame(title);
            return View(new Slide());
        }

        //
        // POST: /AdminBannerImage/Create

        [HttpPost]
        public ActionResult Create(Slide slides)
        {
            if (ModelState.IsValid)
            {
                db.Slides.Add(slides);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            CreateFrame(title);
            return View(slides);
        }

        //
        // GET: /AdminBannerImage/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Slide slides = db.Slides.Find(id);
            if (slides == null)
            {
                return HttpNotFound();
            }
            CreateFrame(title);
            return View(slides);
        }

        //
        // POST: /AdminBannerImage/Edit/5

        [HttpPost]
        public ActionResult Edit(Slide slides)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slides).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slides);
        }

        //
        // GET: /AdminBannerImage/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Slide slides = db.Slides.Find(id);
            if (slides == null)
            {
                return HttpNotFound();
            }
            db.Slides.Remove(slides);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }

        //
        // POST: /AdminBannerImage/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(List<int> ids)
        {
            var objs = db.Slides.Where(p => ids.Contains(p.Id));
            foreach (var obj in objs)
            {
                db.Slides.Remove(obj);
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