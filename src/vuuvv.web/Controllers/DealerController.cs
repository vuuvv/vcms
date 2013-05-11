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
    public class DealerController : Controller
    {
        VDB db = new VDB();
        //
        // GET: /Dealer/

        public ActionResult Index()
        {
            var china = db.Area.First(a => a.Id == 1);
            ViewBag.provinces = china.Children.ToList();
            var rpage = RenderPage.Create(db, "sales/dealer");
            return View(rpage);
        }

        public ActionResult DealerList(int id)
        {
            var area = db.Area.First(a => a.Id == id);
            var root = Area.CreateTree(db.Area.ToArray(), area);

            List<Dealer> dealers = new List<Dealer>();
            if (!root.HasChildren)
            {
                dealers = root.Data.Dealers.ToList();
            }
            else
            {
                foreach (var a in root.Leafs)
                {
                    dealers = dealers.Union(a.Data.Dealers).ToList();
                }
            }
            List<Dictionary<string, object>> jdealers = new List<Dictionary<string, object>>();
            foreach (var d in dealers)
            {
                var obj = ClassHelper.ToDictionary(d, "Id", "Address", "Contact", "Tel", "Mobile", "Fax", "Website", "Zipcode", "latitude", "longitude");
                obj.Add("Name", d.MyArea.Name);
                jdealers.Add(obj);
            }
            return Json(new { dealers = jdealers }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CitiesList(int id)
        {
            var province = db.Area.First(a => a.Id == id);
            var children = province.Children.ToList();
            List<Dictionary<string, object>> cities = new List<Dictionary<string, object>>();
            foreach (var c in children)
            {
                cities.Add(ClassHelper.ToDictionary(c, "Id", "ParentId", "Name"));
            }

            return Json(new { cities = cities }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Province(string name)
        {
            var province = db.Area.First(a => a.Name == name);

            var root = Area.CreateTree(db.Area.ToArray(), province);
            List<Dealer> dealers = new List<Dealer>();
            foreach (var a in root.Leafs)
            {
                dealers = dealers.Union(a.Data.Dealers).ToList();
            }
            List<Dictionary<string, object>> jdealers = new List<Dictionary<string, object>>();
            foreach (var d in dealers)
            {
                var obj = ClassHelper.ToDictionary(d, "Id", "Name", "Address", "Contact", "Tel", "Mobile", "Fax", "Website", "Zipcode", "latitude", "longitude");
                jdealers.Add(obj);
            }

            var children = province.Children.ToList();
            List<Dictionary<string, object>> cities = new List<Dictionary<string, object>>();
            foreach (var c in children)
            {
                cities.Add(ClassHelper.ToDictionary(c, "Id", "ParentId", "Name"));
            }

            return Json(new { id = province.Id, dealers = jdealers, cities = cities }, JsonRequestBehavior.AllowGet);
        }
    }
}
