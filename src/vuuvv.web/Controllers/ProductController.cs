using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;

using vuuvv.web.Helper;
using vuuvv.web.Models;
using vuuvv.web.Models.ViewModel;

namespace vuuvv.web.Controllers
{
    public class ProductController : Controller
    {
        private VDB db = new VDB();
        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StyleIndex(string slug)
        {
            var category = db.StyleCategories.Include("Styles").First(c => c.Slug == slug.ToLower());
            var rpage = RenderPage.Create(db, "product/style");
            ViewBag.category = category;
            return View(rpage);
        }

        public ActionResult StyleDetail(string slug)
        {
            var style = db.Styles.First(c => c.Slug == slug.ToLower());
            var rpage = RenderPage.Create(db, "product/style", style.Name);

            var pressPage = new WebPage();
            pressPage.Title = style.Name;
            var pressNode = new Node<WebPage>();
            pressNode.Data = pressPage;
            rpage.Ancestors.Insert(0, pressNode);

            ViewBag.style = style;

            return View(rpage);
        }

        public ActionResult ProductCategoryList(string category)
        {
            int page = 1;
            string view = "ProductCategoryList";
            category = category.ToLower().Trim('/');
            Regex regex = new Regex(@"^(?<category>.+)/p/(?<page>\d+)$");
            var matches = regex.Matches(category);
            if (matches.Count > 0)
            {
                category = matches[0].Groups["category"].Value;
                page = Convert.ToInt32(matches[0].Groups["page"].Value);
            }

            if (category == "" || category == null || category == "joyou")
            {
                category = "joyou";
                view = "ProductCategoryTop";
            }

            var current = db.ProductCategories.First(c => c.Url == category);
            var node = ProductCategory.CreateTree(db.ProductCategories.ToArray(), current);
            var rpage = RenderPage.Create(db, "product", current.Name);

            var currentNode = node;
            var fakeAncestors = new List<Node<WebPage>>();
            int count = rpage.Ancestors.Count;
            do
            {
                var fakePage = new Node<WebPage>();
                fakePage.Data = new WebPage();
                fakePage.Data.Title = currentNode.Data.Name;
                fakePage.Data.Url = string.Format("product/{0}", currentNode.Data.Url);
                rpage.Ancestors.Insert(count, fakePage);
                currentNode = currentNode.Parent;
            } while (currentNode != null);

            if (!node.HasChildren)
            {
                view = "ProductList";
                var urlPrefix = string.Format("/product/{0}", node.Data.Url);
                ViewBag.helper = new PPager<Product>(current.Products.OrderByDescending(p => p.CreatedDate), page, urlPrefix, 16);
            }

            ViewBag.category = node;

            return View(view, rpage);
        }

        public ActionResult ProductDetail(string slug)
        {
            Product product;

            if (slug == null)
            {
                product = db.Products.OrderByDescending(p => p.CreatedDate).First();
            }
            else
            {
                slug = slug.ToLower().Trim('/');
                product = db.Products.First(p => p.Slug == slug);
            }

            var category = product.Categories[0];
            var rpage = RenderPage.Create(db, "product", product.Name);

            ViewBag.product = product;
            return View(rpage);
        }
    }
}
