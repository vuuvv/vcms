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
    public class AdminConferenceArticleController : Controller
    {
        private VDB db = new VDB();

        //
        // GET: /AdminConferenceArticle/

        public ActionResult Index()
        {
            var conferencearticles = db.ConferenceArticles.Include(c => c.Column);
            return View(conferencearticles.ToList());
        }

        //
        // GET: /AdminConferenceArticle/Details/5

        public ActionResult Details(int id = 0)
        {
            ConferenceArticle conferencearticle = db.ConferenceArticles.Find(id);
            if (conferencearticle == null)
            {
                return HttpNotFound();
            }
            return View(conferencearticle);
        }

        //
        // GET: /AdminConferenceArticle/Create

        public ActionResult Create()
        {
            ViewBag.ColumnId = new SelectList(db.ConferenceColumn, "Id", "Name");
            return View();
        }

        //
        // POST: /AdminConferenceArticle/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ConferenceArticle conferencearticle)
        {
            this.ValidateRequest = false;
            if (ModelState.IsValid)
            {
                db.ConferenceArticles.Add(conferencearticle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColumnId = new SelectList(db.ConferenceColumn, "Id", "Name", conferencearticle.ColumnId);
            return View(conferencearticle);
        }

        //
        // GET: /AdminConferenceArticle/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ConferenceArticle conferencearticle = db.ConferenceArticles.Find(id);
            if (conferencearticle == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColumnId = new SelectList(db.ConferenceColumn, "Id", "Name", conferencearticle.ColumnId);
            return View(conferencearticle);
        }

        //
        // POST: /AdminConferenceArticle/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ConferenceArticle conferencearticle)
        {
            this.ValidateRequest = false;
            if (ModelState.IsValid)
            {
                db.Entry(conferencearticle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColumnId = new SelectList(db.ConferenceColumn, "Id", "Name", conferencearticle.ColumnId);
            return View(conferencearticle);
        }

        //
        // GET: /AdminConferenceArticle/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ConferenceArticle conferencearticle = db.ConferenceArticles.Find(id);
            if (conferencearticle == null)
            {
                return HttpNotFound();
            }
            return View(conferencearticle);
        }

        //
        // POST: /AdminConferenceArticle/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ConferenceArticle conferencearticle = db.ConferenceArticles.Find(id);
            db.ConferenceArticles.Remove(conferencearticle);
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