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
    public class AdminPressCategoryController : AdminController
    {
        private VDB db = new VDB();
        private string title = "新闻管理";

        //
        // GET: /AdminPressCategory/

        public ActionResult Index()
        {
            CreateFrame(title);
            return View(db.PressCategories.ToList());
        }

        //
        // GET: /AdminPressCategory/Details/5

        public ActionResult Details(int id = 0)
        {
            PressCategory presscategory = db.PressCategories.Find(id);
            if (presscategory == null)
            {
                return HttpNotFound();
            }
            return View(presscategory);
        }

        //
        // GET: /AdminPressCategory/Create

        public ActionResult Create()
        {
            CreateFrame(title);
            return View();
        }

        //
        // POST: /AdminPressCategory/Create

        [HttpPost]
        public ActionResult Create(PressCategory presscategory)
        {
            if (ModelState.IsValid)
            {
                db.PressCategories.Add(presscategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            CreateFrame(title);
            return View(presscategory);
        }

        //
        // GET: /AdminPressCategory/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CreateFrame(title);
            PressCategory presscategory = db.PressCategories.Find(id);
            if (presscategory == null)
            {
                return HttpNotFound();
            }
            return View(presscategory);
        }

        //
        // POST: /AdminPressCategory/Edit/5

        [HttpPost]
        public ActionResult Edit(PressCategory presscategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(presscategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(presscategory);
        }

        //
        // GET: /AdminPressCategory/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PressCategory presscategory = db.PressCategories.Find(id);
            if (presscategory == null)
            {
                return HttpNotFound();
            }
            db.PressCategories.Remove(presscategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /AdminPressCategory/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteMultiple(List<int> ids)
        {
            var objs = db.PressCategories.Where(p => ids.Contains(p.Id));
            foreach (var obj in objs)
            {
                db.PressCategories.Remove(obj);
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