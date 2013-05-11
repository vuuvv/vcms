using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using vuuvv.web.Helper;
using vuuvv.web.Models;

namespace vuuvv.web.Controllers
{
    public class AdminProductController : AdminController
    {
        private VDB db = new VDB();
        private string title = "产品管理";

        //
        // GET: /AdminProduct/

        public ActionResult Index(int page = 1)
        {
            CreateFrame(title);
            var items = db.Products.OrderByDescending(p => p.CreatedDate);
            var helper = new PPager<Product>(items, page, "/manage/adminproduct");
            return View(helper);
        }

        public ActionResult Search(string keyword, int page = 1)
        {
            CreateFrame(title);
            var items = db.Products.Where(p => p.Sku.Contains(keyword.ToLower()) || p.Name.Contains(keyword)).OrderByDescending(p => p.CreatedDate);
            var helper = new Pager<Product>(items, page, "/manage/adminproduct/search/" + keyword);
            return View("Index", helper);
        }

        //
        // GET: /AdminProduct/Details/5

        public ActionResult Details(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // GET: /AdminProduct/Create

        public ActionResult Create()
        {
            ViewBag.Categories = db.ProductCategories.ToList();
            ViewBag.SelectedCategories = new List<ProductCategory>();
            ViewBag.Technologies = db.Technologies.ToList();
            ViewBag.SelectedTechnologies = new List<Technology>();
            CreateFrame(title);
            var product = new Product();
            product.Active = true;
            return View(product);
        }

        //
        // POST: /AdminProduct/Create

        [HttpPost]
        public ActionResult Create(Product product, List<int> CategoryIds, List<int> TechnologyIds)
        {
            foreach (var id in CategoryIds)
            {
                var category = db.ProductCategories.Find(id);
                if (category != null)
                    product.Categories.Add(category);
            }

            if (TechnologyIds != null)
            {
                foreach (var id in TechnologyIds)
                {
                    var technology = db.Technologies.Find(id);
                    if (technology != null)
                        product.Technologies.Add(technology);
                }
            }

            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = db.ProductCategories.ToList();
            ViewBag.SelectedCategories = product.Categories;
            CreateFrame(title);
            return View(product);
        }

        //
        // GET: /AdminProduct/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Product product = db.Products.Find(id);
            ViewBag.Categories = db.ProductCategories.ToList();
            ViewBag.SelectedCategories = product.Categories;
            ViewBag.Technologies = db.Technologies.ToList();
            ViewBag.SelectedTechnologies = product.Technologies;
            if (product == null)
            {
                return HttpNotFound();
            }
            CreateFrame(title);
            return View(product);
        }

        //
        // POST: /AdminProduct/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product, List<int> CategoryIds, List<int> TechnologyIds)
        {

            using (var mdb = new VDB())
            {
                var mproduct = mdb.Products
                    .Include(i => i.Categories).Include(i => i.Technologies)
                    .Where(i => i.Id == product.Id)
                    .Single();
                mproduct.Categories.Clear();
                foreach (var id in CategoryIds)
                {
                    var category = mdb.ProductCategories.Find(id);
                    if (category != null)
                        mproduct.Categories.Add(category);
                }
                mproduct.Technologies.Clear();
                if (TechnologyIds != null)
                {
                    foreach (var id in TechnologyIds)
                    {
                        var technology = mdb.Technologies.Find(id);
                        if (technology != null)
                            mproduct.Technologies.Add(technology);
                    }
                }

                mdb.Entry(mproduct).State = EntityState.Modified;
                mdb.SaveChanges();
            }

            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = db.ProductCategories.ToList();
            ViewBag.SelectedCategories = product.Categories;
            CreateFrame(title);
            return View(product);

            /*
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            CreateFrame(title);
            return View(product);
            */
        }

        private void UpdateProductsCategories(List<int> CategoryIds, Product product)
        {
            if (CategoryIds == null)
            {
                product.Categories = new List<ProductCategory>();
                return;
            }

            var selectedCategories = new HashSet<int>(CategoryIds);
            var productCategories = new HashSet<int>(
                product.Categories.Select(c => c.Id));

            foreach (var c in db.ProductCategories)
            {

            }

        }

        //
        // GET: /AdminProduct/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            db.Products.Remove(product);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }

        //
        // POST: /AdminProduct/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(List<int> ids)
        {
            var objs = db.Products.Where(p => ids.Contains(p.Id));
            foreach (var obj in objs)
            {
                db.Products.Remove(obj);
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