using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vuuvv.web.Models.ViewModel
{
    public class SideBarItem
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public List<SideBarItem> Children { get; set; }
    }

    public class BreadCrumbItem
    {
        public string Title { get; set; }
        public string Url { get; set; }
    }

    public class AdminFrame
    {
        public AdminFrame()
        {
            Sidebar = CreateSidebar();
            Breadcrumb = new List<BreadCrumbItem>();
        }

        public string Title { get; set; }
        public List<SideBarItem> Sidebar { get; set; }
        public List<BreadCrumbItem> Breadcrumb { get; set; }

        public static List<SideBarItem> CreateSidebar () 
        {
            var sidebar = new List<SideBarItem>();

            var account = new SideBarItem { Title = "帐户管理", Url = "account", Icon = "user-md" };
            var user = new SideBarItem { Title = "用户", Url = "user" };
            var role = new SideBarItem { Title = "角色", Url = "role" };
            account.Children = new List<SideBarItem>();
            account.Children.Add(user);
            account.Children.Add(role);
            sidebar.Add(account);

            var page = new SideBarItem { Title = "页面管理", Url = "webpage", Icon = "envelope" };
            sidebar.Add(page);

            var slide = new SideBarItem { Title = "首页幻灯片", Url = "slide", Icon = "envelope" };
            sidebar.Add(slide);

            var press = new SideBarItem { Title = "新闻管理", Url = "press", Icon = "book" };
            var pressCategory = new SideBarItem { Title = "新闻类别", Url = "presscategory" };
            var pressContent = new SideBarItem { Title = "新闻内容", Url = "press" };
            press.Children = new List<SideBarItem>();
            press.Children.Add(pressCategory);
            press.Children.Add(pressContent);
            sidebar.Add(press);

            var product = new SideBarItem { Title = "产品管理", Url = "product", Icon = "fire" };
            var productCategory = new SideBarItem { Title = "产品类别", Url = "productcategory" };
            var productContent = new SideBarItem { Title = "产品内容", Url = "product" };
            var technologyContent = new SideBarItem { Title = "中宇技术", Url = "technology" };
            var bannerImage = new SideBarItem { Title = "横幅幻灯片", Url = "bannerimage" };
            product.Children = new List<SideBarItem>();
            product.Children.Add(productCategory);
            product.Children.Add(productContent);
            product.Children.Add(technologyContent);
            product.Children.Add(bannerImage);
            sidebar.Add(product);

            var sales = new SideBarItem { Title = "销售网络", Url = "product", Icon = "fire" };
            var salesArea = new SideBarItem { Title = "区域", Url = "area" };
            var salesDealer = new SideBarItem { Title = "经销商", Url = "dealer" };
            var caseCategory = new SideBarItem { Title = "工程案例分类", Url = "caseCategory" };
            var caseItem = new SideBarItem { Title = "工程案例", Url = "case" };
            sales.Children = new List<SideBarItem>();
            sales.Children.Add(salesArea);
            sales.Children.Add(salesDealer);
            sales.Children.Add(caseCategory);
            sales.Children.Add(caseItem);
            sidebar.Add(sales);

            return sidebar;
        }
    }
}