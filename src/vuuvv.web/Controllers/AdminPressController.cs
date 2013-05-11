using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using vuuvv.web.Helper;
using vuuvv.web.Models;
using vuuvv.web.Models.ViewModel;

namespace vuuvv.web.Controllers
{
    public class AdminPressController : AdminController
    {
        private VDB db = new VDB();
        protected string title = "新闻管理";

        //
        // GET: /AdminPress/

        public ActionResult Index(int page = 1)
        {
            CreateFrame(title);
            var items = db.Press.Include(p => p.Category).OrderByDescending(p => p.CreatedDate);
            var helper = new PPager<Press>(items, page, "/manage/adminpress");
            return View(helper);
        }

        public ActionResult Search(string keyword, int page = 1)
        {
            CreateFrame(title);
            var items = db.Press.Where(p => p.Title.Contains(keyword) || p.Title.Contains(keyword)).OrderByDescending(p => p.CreatedDate);
            var helper = new PPager<Press>(items, page, "/manage/adminpress/search/" + keyword);
            return View("Index", helper);
        }

        //
        // GET: /AdminPress/Details/5

        public ActionResult Details(int id = 0)
        {
            Press press = db.Press.Find(id);
            if (press == null)
            {
                return HttpNotFound();
            }
            return View(press);
        }

        //
        // GET: /AdminPress/Create

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.PressCategories, "Id", "Name");
            CreateFrame(title);
            var press = new Press();
            press.CreatedDate = DateTime.Now;
            press.Active = true;
            return View(press);
        }

        //
        // POST: /AdminPress/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Press press)
        {
            this.ValidateRequest = false;
            if (ModelState.IsValid)
            {
                db.Press.Add(press);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.PressCategories, "Id", "Name", press.CategoryId);
            CreateFrame(title);
            return View(press);
        }

        //
        // GET: /AdminPress/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Press press = db.Press.Find(id);
            if (press == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.PressCategories, "Id", "Name", press.CategoryId);
            CreateFrame(title);
            return View(press);
        }

        //
        // POST: /AdminPress/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Press press)
        {
            this.ValidateRequest = false;
            if (ModelState.IsValid)
            {
                db.Entry(press).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.PressCategories, "Id", "Name", press.CategoryId);
            return View(press);
        }

        //
        // GET: /AdminPress/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Press press = db.Press.Find(id);
            if (press == null)
            {
                return HttpNotFound();
            }
            db.Press.Remove(press);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /AdminPress/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(List<int> ids)
        {
            var objs = db.Press.Where(p => ids.Contains(p.Id));
            foreach (var obj in objs)
            {
                db.Press.Remove(obj);
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