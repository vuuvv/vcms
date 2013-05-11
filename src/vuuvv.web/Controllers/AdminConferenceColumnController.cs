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
    public class AdminConferenceColumnController : Controller
    {
        private VDB db = new VDB();

        //
        // GET: /AdminConferenceColumn/

        public ActionResult Index()
        {
            return View(db.ConferenceColumn.ToList());
        }

        //
        // GET: /AdminConferenceColumn/Details/5

        public ActionResult Details(int id = 0)
        {
            ConferenceColumn conferencecolumn = db.ConferenceColumn.Find(id);
            if (conferencecolumn == null)
            {
                return HttpNotFound();
            }
            return View(conferencecolumn);
        }

        //
        // GET: /AdminConferenceColumn/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AdminConferenceColumn/Create

        [HttpPost]
        public ActionResult Create(ConferenceColumn conferencecolumn)
        {
            if (ModelState.IsValid)
            {
                db.ConferenceColumn.Add(conferencecolumn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(conferencecolumn);
        }

        //
        // GET: /AdminConferenceColumn/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ConferenceColumn conferencecolumn = db.ConferenceColumn.Find(id);
            if (conferencecolumn == null)
            {
                return HttpNotFound();
            }
            return View(conferencecolumn);
        }

        //
        // POST: /AdminConferenceColumn/Edit/5

        [HttpPost]
        public ActionResult Edit(ConferenceColumn conferencecolumn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conferencecolumn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(conferencecolumn);
        }

        //
        // GET: /AdminConferenceColumn/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ConferenceColumn conferencecolumn = db.ConferenceColumn.Find(id);
            if (conferencecolumn == null)
            {
                return HttpNotFound();
            }
            return View(conferencecolumn);
        }

        //
        // POST: /AdminConferenceColumn/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ConferenceColumn conferencecolumn = db.ConferenceColumn.Find(id);
            db.ConferenceColumn.Remove(conferencecolumn);
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