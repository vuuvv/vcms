using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vuuvv.Domain.Entities.Service;

namespace vuuvv.web.Areas.Service.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var nav = new Navigation[] {
                new Navigation { Title = "走进社区", Link = Url.Action("") },
                new Navigation { Title = "会员专区", Link = Url.Action("") },
                new Navigation { Title = "互动专区", Link = Url.Action("") },
                new Navigation { Title = "动态公告", Link = Url.Action("") },
                new Navigation { Title = "网点查询", Link = Url.Action("") },
                new Navigation { Title = "客服咨询", Link = Url.Action("") },
                new Navigation { Title = "卫浴大讲堂", Link = Url.Action("") },
                new Navigation { Title = "关于我们", Link = Url.Action("") }
            };

            var carousel = new Carousel[] {
                new Carousel { Name = "", Link = Url.Action(""), Image = "/static/service/img/c1.png" },
                new Carousel { Name = "", Link = Url.Action(""), Image = "/static/service/img/c2.png" },
                new Carousel { Name = "", Link = Url.Action(""), Image = "/static/service/img/c3.png" },
            };

            ViewBag.Nav = nav;
            return View(carousel);
        }
    }
}
