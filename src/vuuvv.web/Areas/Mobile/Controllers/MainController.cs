using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vuuvv.Domain.Entities.Mobile;

namespace vuuvv.web.Areas.Mobile.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /Mobile/Test/

        public ActionResult Index()
        {
            var navigations = new Navigation[]
            {
                new Navigation { Name = "展厅导览 Hall Tour", ViewName = "Hall" },
                new Navigation { Name = "工程套间 Engineering Suiteall", ViewName = "Suit" },
                new Navigation { Name = "精品荟萃 Exquisite Products", ViewName = "Products" },
                new Navigation { Name = "活动议程 Activity Agenda", ViewName = "Agenda" },
                new Navigation { Name = "互动链接 Interactive Links", ViewName = "Links" },
                new Navigation { Name = "资讯速递 Courier News", ViewName = "News" },
                new Navigation { Name = "走进中宇 About JOYOU", ViewName = "About" },
            };
            return View("Index", navigations);
        }

    }
}
