using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using vuuvv.web.Filters;
using vuuvv.web.Models.ViewModel;

namespace vuuvv.web.Controllers
{
    [AuthorizeFilter]
    public class AdminController : Controller
    {
        protected AdminFrame CreateFrame(string title)
        {
            var frame = new AdminFrame();
            frame.Title = title;
            ViewBag.Frame = frame;
            return frame;
        }
    }
}
