using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using vuuvv.web.Models;
using vuuvv.web.Models.ViewModel;

namespace vuuvv.web.Controllers
{
    public class JobController : Controller
    {
        private VDB db = new VDB();
        //
        // GET: /Job/

        public ActionResult Index()
        {
            var rpage = RenderPage.Create(db, "about");
            ViewBag.jobs = db.Jobs.OrderByDescending(j => j.PublishDate).ToList();
            return View(rpage);
        }

    }
}
