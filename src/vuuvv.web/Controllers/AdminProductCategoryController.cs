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
    public class AdminProductCategoryController : AdminController
    {
        private VDB db = new VDB();
        private string title = "产品管理";

        //
        // GET: /AdminProductCategory/

        public ActionResult Index(int? id)
        {
            CreateFrame(title);
            IQueryable<ProductCategory> categories = null;
            var category = db.WebPages.Find(id);
            if (category == null)
                categories = db.ProductCategories.Include(w => w.Parent).Where(w => w.ParentId == null);
            else
                categories = db.ProductCategories.Include(w => w.Parent).Where(w => w.ParentId == id);
            ViewBag.item = category;
            return View(categories.ToList());
        }

        //
        // GET: /AdminProductCategory/Details/5

        public ActionResult Details(int id = 0)
        {
            ProductCategory productcategory = db.ProductCategories.Find(id);
            if (productcategory == null)
            {
                return HttpNotFound();
            }
            return View(productcategory);
        }

        //
        // GET: /AdminProductCategory/Create

        public ActionResult Create(int? id)
        {
            CreateFrame(title);
            var parent = db.ProductCategories.Find(id);
            ViewBag.ParentId = new SelectList(db.ProductCategories, "Id", "Name", id);
            var category = new ProductCategory();
            category.Active = true;
            /*
            if (parent != null)
            {
                category.Url = parent.Url + "/";
            }
            */
            return View(category);
        }

        //
        // POST: /AdminProductCategory/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ProductCategory productcategory, string nextStep)
        {
            this.ValidateRequest = false;
            if (ModelState.IsValid)
            {
                db.ProductCategories.Add(productcategory);
                db.SaveChanges();
                return Redirect(nextStep);
            }

            ViewBag.ParentId = new SelectList(db.ProductCategories, "Id", "Name", productcategory.ParentId);
            CreateFrame(title);
            return View(productcategory);
        }

        //
        // GET: /AdminProductCategory/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ProductCategory productcategory = db.ProductCategories.Find(id);
            if (productcategory == null)
            {
                return HttpNotFound();
            }
            CreateFrame(title);
            ViewBag.ParentId = new SelectList(db.ProductCategories, "Id", "Name", productcategory.ParentId);
            return View(productcategory);
        }

        //
        // POST: /AdminProductCategory/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ProductCategory productcategory, string nextStep)
        {
            this.ValidateRequest = false;
            if (ModelState.IsValid)
            {
                db.Entry(productcategory).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(nextStep);
            }
            ViewBag.ParentId = new SelectList(db.ProductCategories, "Id", "Name", productcategory.ParentId);
            return View(productcategory);
        }

        //
        // GET: /AdminProductCategory/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ProductCategory productcategory = db.ProductCategories.Find(id);
            if (productcategory == null)
            {
                return HttpNotFound();
            }
            db.ProductCategories.Remove(productcategory);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }

        //
        // POST: /AdminProductCategory/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(List<int> ids)
        {
            var productcategories = db.ProductCategories.Where(p=>ids.Contains(p.Id));
            foreach (var category in productcategories)
            {
                db.ProductCategories.Remove(category);
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