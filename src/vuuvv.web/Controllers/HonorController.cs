using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using vuuvv.web.Models;
using vuuvv.web.Models.ViewModel;

namespace vuuvv.web.Controllers
{
    public class HonorController : Controller
    {
        private VDB db = new VDB();
        //
        // GET: /Honor/

        public ActionResult List(string slug)
        {
            HonorCategory category;
            if (slug == null || slug == "")
            {
                category = db.HonorCategory.First();
            }
            else
            {
                category = db.HonorCategory.First(c => c.Slug == slug);
            }
            var rpage = RenderPage.Create(db, "about/honor", category.Name);
            ViewBag.categories = db.HonorCategory.ToList();
            ViewBag.honors = db.Honor.OrderByDescending(h => h.Year).Where(h => h.CategoryId == category.Id).ToList();
            ViewBag.category = category;
            return View(rpage);
        }

    }
}
