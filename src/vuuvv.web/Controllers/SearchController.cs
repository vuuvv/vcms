using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using vuuvv.web.Models;
using vuuvv.web.Models.ViewModel;
using vuuvv.web.Helper;

namespace vuuvv.web.Controllers
{
    public class SearchController : Controller
    {
        private VDB db = new VDB();
        //
        // GET: /Search/

        public ActionResult Index(string slug, int page)
        {
            var rpage = RenderPage.Create(db, "about");
            rpage.Ancestors[rpage.Ancestors.Count - 1].Data.Title = "搜索结果";
            var products = db.Products.Where(p => p.Slug.Contains(slug.ToLower()) || p.Name.Contains(slug));
            ViewBag.helper = new Pager<Product>(products, page, "/search/" + slug, 16);
            ViewBag.Title = slug;

            return View(rpage);
        }

    }
}
