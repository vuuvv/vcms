using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vuuvv.web.Models;
using vuuvv.web.Models.ViewModel;

namespace vuuvv.web.Controllers
{
    public class PageController : Controller
    {
        //
        // GET: /Page/
        private VDB db = new VDB();

        public ActionResult Render(string url)
        {
            return View(RenderPage.Create(db, url.Trim('/')));
        }

    }
}
