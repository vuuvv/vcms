using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using vuuvv.web.Helper;
using vuuvv.web.Framework.Security;

namespace vuuvv.web.Areas.Admin.Controllers
{
    public class TestController : SecurityController
    {
        public ActionResult Index()
        {
            return View(ClassHelper.GetAllSubClass(typeof(SecurityController), false, true));
        }
    }
}
