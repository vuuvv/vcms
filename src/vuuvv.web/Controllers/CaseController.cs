using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using vuuvv.web.Models;
using vuuvv.web.Models.ViewModel;

namespace vuuvv.web.Controllers
{
    public class CaseController : Controller
    {
        private VDB db = new VDB();
        //
        // GET: /Case/

        public ActionResult Index(string slug)
        {
            slug = slug.ToLower().Trim('/');
            var rpage = RenderPage.Create(db, "sales/cases/" + slug);
            ViewBag.category = db.CaseCategory.First(c => c.Slug == slug);
            return View(rpage);
        }

    }
}
