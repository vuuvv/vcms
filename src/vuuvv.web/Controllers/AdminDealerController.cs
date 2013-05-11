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
    public class AdminDealerController : AdminController
    {
        private VDB db = new VDB();
        private string title = "销售管理";

        //
        // GET: /AdminDealer/

        public ActionResult Index()
        {
            CreateFrame(title);
            var dealers = db.Dealer.Include(p => p.MyArea);
            return View(dealers.ToList());
        }

        //
        // GET: /AdminDealer/Details/5

        public ActionResult Details(int id = 0)
        {
            Dealer dealer = db.Dealer.Find(id);
            if (dealer == null)
            {
                return HttpNotFound();
            }
            return View(dealer);
        }

        //
        // GET: /AdminDealer/Create

        public ActionResult Create()
        {
            ViewBag.AreaId = new SelectList(db.Area, "Id", "Name");
            CreateFrame(title);
            var dealer = new Dealer();
            dealer.Active = true;
            return View(dealer);
        }

        //
        // POST: /AdminDealer/Create

        [HttpPost]
        public ActionResult Create(Dealer dealer)
        {
            if (ModelState.IsValid)
            {
                db.Dealer.Add(dealer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaId = new SelectList(db.Area, "Id", "Name", dealer.AreaId);
            CreateFrame(title);
            return View(dealer);
        }

        //
        // GET: /AdminDealer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Dealer dealer = db.Dealer.Find(id);
            if (dealer == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaId = new SelectList(db.Area, "Id", "Name", dealer.AreaId);
            CreateFrame(title);
            return View(dealer);
        }

        //
        // POST: /AdminDealer/Edit/5

        [HttpPost]
        public ActionResult Edit(Dealer dealer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dealer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaId = new SelectList(db.Area, "Id", "Name", dealer.AreaId);
            return View(dealer);
        }

        //
        // GET: /AdminDealer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Dealer dealer = db.Dealer.Find(id);
            if (dealer == null)
            {
                return HttpNotFound();
            }
            db.Dealer.Remove(dealer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /AdminDealer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(List<int> ids)
        {
            var objs = db.Dealer.Where(p => ids.Contains(p.Id));
            foreach (var obj in objs)
            {
                db.Dealer.Remove(obj);
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