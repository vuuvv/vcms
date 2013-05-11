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
    public class AdminCaseCategoryController : AdminController
    {
        private VDB db = new VDB();
        private string title = "工程案例分类";

        //
        // GET: /AdminPressCategory/

        public ActionResult Index()
        {
            CreateFrame(title);
            return View(db.CaseCategory.OrderBy(c => c.Ordering).ToList());
        }

        //
        // GET: /AdminPressCategory/Details/5

        public ActionResult Details(int id = 0)
        {
            CaseCategory casecategory = db.CaseCategory.Find(id);
            if (casecategory == null)
            {
                return HttpNotFound();
            }
            return View(casecategory);
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
        public ActionResult Create(CaseCategory casecategory)
        {
            if (ModelState.IsValid)
            {
                db.CaseCategory.Add(casecategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            CreateFrame(title);
            return View(casecategory);
        }

        //
        // GET: /AdminPressCategory/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CreateFrame(title);
            CaseCategory casecategory = db.CaseCategory.Find(id);
            if (casecategory == null)
            {
                return HttpNotFound();
            }
            return View(casecategory);
        }

        //
        // POST: /AdminPressCategory/Edit/5

        [HttpPost]
        public ActionResult Edit(CaseCategory casecategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(casecategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(casecategory);
        }

        //
        // GET: /AdminPressCategory/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CaseCategory casecategory = db.CaseCategory.Find(id);
            if (casecategory == null)
            {
                return HttpNotFound();
            }
            db.CaseCategory.Remove(casecategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /AdminPressCategory/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteMultiple(List<int> ids)
        {
            var objs = db.CaseCategory.Where(p => ids.Contains(p.Id));
            foreach (var obj in objs)
            {
                db.CaseCategory.Remove(obj);
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