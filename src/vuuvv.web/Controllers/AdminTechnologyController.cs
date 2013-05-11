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
    public class AdminTechnologyController : AdminController
    {
        private VDB db = new VDB();
        private string title = "中宇技术";

        //
        // GET: /AdminBannerImage/

        public ActionResult Index()
        {
            CreateFrame(title);
            return View(db.Technologies.ToList());
        }

        //
        // GET: /AdminBannerImage/Details/5

        public ActionResult Details(int id = 0)
        {
            Technology technologie = db.Technologies.Find(id);
            if (technologie == null)
            {
                return HttpNotFound();
            }
            return View(technologie);
        }

        //
        // GET: /AdminBannerImage/Create

        public ActionResult Create()
        {
            CreateFrame(title);
            return View(new Technology());
        }

        //
        // POST: /AdminBannerImage/Create

        [HttpPost]
        public ActionResult Create(Technology technologie)
        {
            if (ModelState.IsValid)
            {
                db.Technologies.Add(technologie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            CreateFrame(title);
            return View(technologie);
        }

        //
        // GET: /AdminBannerImage/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Technology technologie = db.Technologies.Find(id);
            if (technologie == null)
            {
                return HttpNotFound();
            }
            CreateFrame(title);
            return View(technologie);
        }

        //
        // POST: /AdminBannerImage/Edit/5

        [HttpPost]
        public ActionResult Edit(Technology technologie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(technologie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(technologie);
        }

        //
        // GET: /AdminBannerImage/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Technology technologie = db.Technologies.Find(id);
            if (technologie == null)
            {
                return HttpNotFound();
            }
            db.Technologies.Remove(technologie);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }

        //
        // POST: /AdminBannerImage/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(List<int> ids)
        {
            var objs = db.Technologies.Where(p => ids.Contains(p.Id));
            foreach (var obj in objs)
            {
                db.Technologies.Remove(obj);
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