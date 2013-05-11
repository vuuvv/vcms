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
    public class AdminUserController : AdminController
    {
        private VDB db = new VDB();
        protected string title = "用户管理";

        //
        // GET: /AdminUser/

        public ActionResult Index(int page = 1)
        {
            CreateFrame(title);
            var items = db.Users.OrderByDescending(p => p.CreatedDate);
            var helper = new PPager<User>(items, page, "/manage/adminuser");
            return View(helper);
        }

        public ActionResult Search(string keyword, int page = 1)
        {
            CreateFrame(title);
            var items = db.Users.Where(p => p.UserName.Contains(keyword)).OrderByDescending(p => p.CreatedDate);
            var helper = new PPager<User>(items, page, "/manage/adminuser/search/" + keyword);
            return View("Index", helper);
        }


        //
        // GET: /AdminUser/Details/5

        public ActionResult Details(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /AdminUser/Create

        public ActionResult Create()
        {
            CreateFrame(title);
            var user = new User();
            return View(user);
        }

        //
        // POST: /AdminUser/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            CreateFrame(title);
            return View(user);
        }

        //
        // GET: /AdminUser/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            CreateFrame(title);
            return View(user);
        }

        //
        // POST: /AdminUser/Edit/5
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }


        //
        // GET: /AdminUser/Delete/5
        public ActionResult Delete(int id = 0)
        {
            var user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //
        // POST: /AdminUser/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(List<int> ids)
        {
            var objs = db.Users.Where(p => ids.Contains(p.Id));
            foreach (var obj in objs)
            {
                db.Users.Remove(obj);
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