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
    public class AdminCaseController : AdminController
    {
        private VDB db = new VDB();
        private string title = "工程案例";

        //
        // GET: /AdminDealer/

        public ActionResult Index()
        {
            CreateFrame(title);
            var items = db.Case.Include(p => p.Category);
            return View(items.ToList());
        }

        //
        // GET: /AdminDealer/Details/5

        public ActionResult Details(int id = 0)
        {
            Case item = db.Case.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        //
        // GET: /AdminDealer/Create

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.CaseCategory, "Id", "Name");
            CreateFrame(title);
            var item = new Case();
            item.Active = true;
            return View(item);
        }

        //
        // POST: /AdminDealer/Create

        [HttpPost]
        public ActionResult Create(Case item)
        {
            if (ModelState.IsValid)
            {
                db.Case.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.CaseCategory, "Id", "Name", item.CategoryId);
            CreateFrame(title);
            return View(item);
        }

        //
        // GET: /AdminDealer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Case item = db.Case.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.CaseCategory, "Id", "Name", item.CategoryId);
            CreateFrame(title);
            return View(item);
        }

        //
        // POST: /AdminDealer/Edit/5

        [HttpPost]
        public ActionResult Edit(Case item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.CaseCategory, "Id", "Name", item.CategoryId);
            return View(item);
        }

        //
        // GET: /AdminDealer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Case item = db.Case.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            db.Case.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /AdminDealer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(List<int> ids)
        {
            var objs = db.Case.Where(p => ids.Contains(p.Id));
            foreach (var obj in objs)
            {
                db.Case.Remove(obj);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}