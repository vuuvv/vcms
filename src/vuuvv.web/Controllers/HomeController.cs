using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using vuuvv.web.Models;
using vuuvv.web.Models.ViewModel;

namespace vuuvv.web.Controllers
{
    public class HomeController : Controller
    {
        private VDB db = new VDB();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.slides = db.Slides.Where(s => s.Active).OrderBy(s => s.Ordering).ToList();
            ViewBag.news = db.Press.Where(p => p.Active).OrderByDescending(p=>p.CreatedDate).ThenByDescending(p => p.CreatedDate).Take(4).ToList();
            var page = RenderPage.Create(db);

            return View(RenderPage.Create(db, "/"));
        }

    }
}
