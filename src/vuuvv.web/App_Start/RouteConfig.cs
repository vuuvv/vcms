using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace vuuvv.web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            string[] exts = { "ico", "png", "jpg", "gif", "js", "css", "swf" };
            foreach (var ext in exts)
            {
                routes.IgnoreRoute("{name}." + ext);
            }
            routes.IgnoreRoute("static/{*file}");
            /*
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            */
            routes.MapRoute(
                "Home",
                "",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                "Search",
                "search/{slug}/{page}",
                defaults: new { controller = "Search", action = "Index", slug = "", page = 1}
            );

            routes.MapRoute(
                "HonorList",
                "about/honor/{slug}",
                new { controller = "Honor", action = "List", slug = UrlParameter.Optional}
            );

            routes.MapRoute(
                "Job",
                "about/jobs",
                new { controller = "Job", action = "Index"}
            );

            routes.MapRoute(
                "Case",
                "sales/cases/{slug}",
                new { controller = "Case", action = "Index", slug = "classic" }
            );

            routes.MapRoute(
                "2013",
                "2013/{id}",
                new { controller = "Conference", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Service",
                "service/{action}",
                new { controller = "Service", action = "Index"}
            );

            RegisterPress(routes);
            RegisterDealer(routes);
            RegisterNews(routes);
            RegisterProduct(routes);

            routes.MapRoute(
                "ManageSearch0",
                "manage/{controller}/search",
                defaults: new { action = "Search"}
            );
            routes.MapRoute(
                "ManageSearch",
                "manage/{controller}/search/{keyword}/{page}",
                defaults: new { action = "Search", keyword = UrlParameter.Optional, page = UrlParameter.Optional }
            );
            routes.MapRoute(
                "ManagePager",
                "manage/{controller}/p/{page}",
                defaults: new { action = "Index", page = UrlParameter.Optional }
            );
            routes.MapRoute(
                "Manage",
                "manage/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                "Default",
                "{*url}",
                new { controller = "Page", action = "Render", url = "" }
            );
        }

        private static void RegisterNews(RouteCollection routes)
        {
            routes.MapRoute(
                "NewsDetail",
                "news/detail/{id}",
                new { controller = "News", action = "Detail", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                "NewsBrand",
                "news/brand/{*path}",
                new { controller = "News", action = "Brand", path = UrlParameter.Optional }
            );
            routes.MapRoute(
                "NewsMagzine",
                "news/magzine/{year}",
                new { controller = "News", action = "Magzine", year = UrlParameter.Optional }
            );
            routes.MapRoute(
                "News",
                "news/{category}/{page}",
                new { controller = "News", action = "Index", category = UrlParameter.Optional, page = 1 }
            );
        }

        private static void RegisterPress(RouteCollection routes)
        {
            routes.MapRoute(
                "PressDetail",
                "press/detail/{id}",
                new { controller = "Press", action = "Detail", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                "PressBrand",
                "press/brand/{*path}",
                new { controller = "Press", action = "Brand", path = UrlParameter.Optional }
            );
            routes.MapRoute(
                "PressMagzine",
                "press/magzine/{year}",
                new { controller = "Press", action = "Magzine", year = UrlParameter.Optional }
            );
            routes.MapRoute(
                "Press",
                "press/{category}/{page}",
                new { controller = "Press", action = "Index", category = UrlParameter.Optional, page = 1 }
            );
        }

        private static void RegisterProduct(RouteCollection routes)
        {
            routes.MapRoute(
                "ProductStyle",
                "product/style/{slug}",
                new { controller = "Product", action = "StyleIndex", slug = "joyou"}
            );

            routes.MapRoute(
                "ProductStyleDetail",
                "product/style/detail/{slug}",
                new { controller = "Product", action = "StyleDetail"}
            );

            routes.MapRoute(
                "ProductDetail",
                "product/detail/{slug}",
                new { controller = "Product", action = "ProductDetail", slug = UrlParameter.Optional}
            );

            routes.MapRoute(
                "ProductCategory",
                "product/{*category}",
                new { controller = "Product", action = "ProductCategoryList", category = ""}
            );
        }

        private static void RegisterHonor(RouteCollection routes)
        {
            routes.MapRoute(
                "HonorList",
                "about/honor/{slug}",
                new { controller = "Honor", action = "List", slug = UrlParameter.Optional}
            );
        }

        private static void RegisterDealer(RouteCollection routes)
        {
            routes.MapRoute(
                "DealerIndex",
                "sales/dealer",
                new { controller = "Dealer", action = "Index"}
            );
            routes.MapRoute(
                "DealerList",
                "sales/dealer/area/{id}",
                new { controller = "Dealer", action = "DealerList" }
            );
            routes.MapRoute(
                "CitiesList",
                "sales/dealer/cities/{id}",
                new { controller = "Dealer", action = "CitiesList", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                "Province",
                "sales/dealer/province/{name}",
                new { controller = "Dealer", action = "Province", name = UrlParameter.Optional }
            );
            routes.MapRoute(
                "Boundary",
                "sales/dealer/boundary",
                new { controller = "Dealer", action = "Boundary" }
            );
        }
    }
}