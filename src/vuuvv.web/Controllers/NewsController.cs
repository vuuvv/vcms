using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using vuuvv.web.Helper;
using vuuvv.web.Models;
using vuuvv.web.Models.ViewModel;

namespace vuuvv.web.Controllers
{
    public class NewsController : Controller
    {
        private VDB db = new VDB();
        //
        // GET: /News/

        public ActionResult Index(string category, int page)
        {
            //return View();
            string url = Request.Url.AbsolutePath;
            RenderPage rpage = null; 

            if (category == null)
            {
                rpage = RenderPage.Create(db, url.Trim('/').Replace("news", "press"));
                var latest = new List<Tuple<PressCategory, List<Press>>>();
                foreach (var cate in db.PressCategories)
                {
                    var presses = db.Press.Where(p => p.CategoryId == cate.Id).OrderByDescending(p=>p.TopOrder).ThenByDescending(p=>p.CreatedDate).Take(3).ToList();
                    latest.Add(new Tuple<PressCategory,List<Press>>(cate, presses));
                }
                var magzines = db.Magzines.OrderByDescending(m => m.Year.Year).Take(3).ToList();
                ViewBag.latest = latest;
                ViewBag.magzines = magzines;
                return View(rpage);
            }
            else
            {
                rpage = RenderPage.Create(db, string.Format("press/{0}", category));
                var cate = db.PressCategories.First(c=>c.Slug == category);
                var articles = db.Press.Where(p => p.CategoryId == cate.Id).OrderByDescending(p=>p.TopOrder).ThenByDescending(p=>p.CreatedDate);
                var urlPrefix = string.Format("/press/{0}", cate.Slug);
                ViewBag.helper = new Pager<Press>(articles, page, urlPrefix, 5);
                return View("Category", rpage);
            }
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                id = db.Press.OrderByDescending(p => p.CreatedDate).Last().Id;
            }
            var article = db.Press.Include("Category").First(p => p.Id == id);
            var url = string.Format("press/{0}", article.Category.Slug);
            var rpage = RenderPage.Create(db, url, article.Title);

            var pressPage = new WebPage();
            pressPage.Title = article.Title;
            var pressNode = new Node<WebPage>();
            pressNode.Data = pressPage;
            rpage.Ancestors.Add(pressNode);

            ViewBag.article = article;

            return View(rpage);
        }

        public ActionResult Brand(string url)
        {
            return View("Render", RenderPage.Create(db, Request.Url.AbsolutePath.Trim('/').Replace("news", "press")));
        }

        public ActionResult Magzine(string year)
        {
            MagzineYear myear;
            if (year == null)
            {
                myear = db.MagzineYears.OrderByDescending(y => y.Year).First();
            }
            else
            {
                myear = db.MagzineYears.First(p => p.Year == Convert.ToInt32(year));
            }

            var rpage = RenderPage.Create(db, "press/magzine");
            ViewBag.magzines = myear.Magzines;

            return View(rpage);
        }
    }
}
