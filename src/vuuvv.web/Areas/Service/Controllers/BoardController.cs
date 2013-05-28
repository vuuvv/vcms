using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vuuvv.web.Areas.Service.Models;

namespace vuuvv.web.Areas.Service.Controllers
{
    public class BoardController : Controller
    {
        //
        // GET: /Service/Board/

        public ActionResult Index()
        {
            ViewBag.PageLayout = PageLayout.Create();
            return View();
        }

    }
}
