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
    public class AdminWebPageController : AdminController
    {
        private VDB db = new VDB();
        private string title = "页面管理";

        //
        // GET: /AdminWebPage/

        public ActionResult Index(int? id)
        {
            CreateFrame(title);
            IQueryable<WebPage> webpages = null;
            var page = db.WebPages.Find(id);
            if (page == null)
                webpages = db.WebPages.Include(w => w.Parent).Where(w => w.ParentId == null);
            else
                webpages = db.WebPages.Include(w => w.Parent).Where(w => w.ParentId == id);
            ViewBag.page = page;
            return View(webpages.OrderBy(w => w.Order).ToList());
        }

        //
        // GET: /AdminWebPage/Details/5

        public ActionResult Details(int id = 0)
        {
            WebPage webpage = db.WebPages.Find(id);
            if (webpage == null)
            {
                return HttpNotFound();
            }
            return View(webpage);
        }

        //
        // GET: /AdminWebPage/Create

        public ActionResult Create(int? id)
        {
            CreateFrame(title);
            var parent = db.WebPages.Find(id);
            ViewBag.ParentId = new SelectList(db.WebPages, "Id", "Url", id);
            var page = new WebPage();
            page.Active = true;
            page.InNavigation = true;
            page.Col = 2;
            if (parent != null)
            {
                page.Url = parent.Url + "/";
            }
            return View(page);
        }

        //
        // POST: /AdminWebPage/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(WebPage webpage, string nextStep)
        {
            this.ValidateRequest = false;
            if (ModelState.IsValid)
            {
                db.WebPages.Add(webpage);
                db.SaveChanges();
                return Redirect(nextStep);
            }

            ViewBag.ParentId = new SelectList(db.WebPages, "Id", "Url", webpage.ParentId);
            CreateFrame(title);
            return View(webpage);
        }

        //
        // GET: /AdminWebPage/Edit/5

        public ActionResult Edit(int id = 0)
        {
            WebPage webpage = db.WebPages.Find(id);
            if (webpage == null)
            {
                return HttpNotFound();
            }
            CreateFrame(title);
            ViewBag.ParentId = new SelectList(db.WebPages, "Id", "Url", webpage.ParentId);
            return View(webpage);
        }

        //
        // POST: /AdminWebPage/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(WebPage webpage, string nextStep)
        {
            this.ValidateRequest = false;
            if (ModelState.IsValid)
            {
                db.Entry(webpage).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(nextStep);
            }
            ViewBag.ParentId = new SelectList(db.WebPages, "Id", "Url", webpage.ParentId);
            return View(webpage);
        }

        //
        // GET: /AdminWebPage/Delete/5

        public ActionResult Delete(int id)
        {
            WebPage webpage = db.WebPages.Find(id);
            if (webpage == null)
            {
                return HttpNotFound();
            }
            db.WebPages.Remove(webpage);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }

        //
        // POST: /AdminWebPage/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(List<int> ids)
        {
            var objs = db.WebPages.Where(p => ids.Contains(p.Id));
            foreach (var obj in objs)
            {
                db.WebPages.Remove(obj);
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