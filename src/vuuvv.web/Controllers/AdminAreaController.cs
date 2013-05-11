using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vuuvv.web.Models;

namespace vuuvv.web.Controllers
{
    public class AdminAreaController : AdminController
    {
        private VDB db = new VDB();
        private string title = "销售管理";

        //
        // GET: /AdminArea/

        public ActionResult Index(int? id)
        {
            CreateFrame(title);
            IQueryable<Area> areas = null;
            var area = db.Area.Find(id);
            if (area == null)
                areas = db.Area.Include(w => w.Parent).Where(w => w.ParentId == null);
            else
                areas = db.Area.Include(w => w.Parent).Where(w => w.ParentId == id);
            ViewBag.page = area;
            return View(areas.ToList());
        }

        //
        // GET: /AdminArea/Details/5

        public ActionResult Details(int id = 0)
        {
            Area area = db.Area.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        //
        // GET: /AdminArea/Create

        public ActionResult Create(int? id)
        {
            CreateFrame(title);
            var parent = db.Area.Find(id);
            ViewBag.ParentId = new SelectList(db.Area, "Id", "Name", id);
            return View();
        }

        //
        // POST: /AdminArea/Create

        [HttpPost]
        public ActionResult Create(Area area, string nextStep)
        {
            if (ModelState.IsValid)
            {
                db.Area.Add(area);
                db.SaveChanges();
                return Redirect(nextStep);
            }

            ViewBag.ParentId = new SelectList(db.Area, "Id", "Name", area.ParentId);
            CreateFrame(title);
            return View(area);
        }

        //
        // GET: /AdminArea/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Area area = db.Area.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            CreateFrame(title);
            ViewBag.ParentId = new SelectList(db.Area, "Id", "Name", area.ParentId);
            return View(area);
        }

        //
        // POST: /AdminArea/Edit/5

        [HttpPost]
        public ActionResult Edit(Area area, string nextStep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(area).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(nextStep);
            }
            ViewBag.ParentId = new SelectList(db.Area, "Id", "Name", area.ParentId);
            return View(area);
        }

        //
        // GET: /AdminArea/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Area area = db.Area.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            db.Area.Remove(area);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }

        //
        // POST: /AdminArea/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(List<int> ids)
        {
            var objs = db.Area.Where(p => ids.Contains(p.Id));
            foreach (var obj in objs)
            {
                db.Area.Remove(obj);
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