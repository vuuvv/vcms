using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using vuuvv.web.Models;

namespace vuuvv.web.Controllers
{
    public class ConferenceController : Controller
    {
        public VDB db = new VDB();
        //
        // GET: /Conference/

        public ActionResult Index(string id)
        {
            int rid = (id == "" || id == null) ? 1 : Convert.ToInt32(id);
            var article = db.ConferenceArticles.First(a => a.Id == rid);
            var columns = db.ConferenceColumn.Include("Articles").ToList();
            ViewBag.article = article;
            return View(columns);
        }
    }
}
