using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using vuuvv.web.Models;
using vuuvv.web.Models.ViewModel;
using vuuvv.web.Helper;

namespace vuuvv.web.Models.ViewModel
{
    public class RenderPage
    {
        public Node<WebPage> Page { get; set; }
        public List<Node<WebPage>> Roots { get; set; }
        public Node<WebPage> Sidebar { get; set; }
        public List<Node<WebPage>> Ancestors { get; set; }
        public string Title { get; set; }

        private Dictionary<int, Node<WebPage>> lookup;
        private Dictionary<int?, List<Node<WebPage>>> children;

        public static RenderPage Create(VDB db, string url)
        {
            url = url.ToLower();
            var current = db.WebPages.Where(p => p.Url == url).FirstOrDefault();
            return CreateTree(db.WebPages.Where(p => p.Active).OrderBy(p=>p.Order).ToArray(), current);
        }

        public static RenderPage Create(VDB db, string url, string title)
        {
            url = url.ToLower();
            var current = db.WebPages.Where(p => p.Url == url).FirstOrDefault();
            var page =  CreateTree(db.WebPages.Where(p => p.Active).OrderBy(p=>p.Order).ToArray(), current);
            page.Title = title;
            return page;
        }

        public static RenderPage Create(VDB db)
        {
            return CreateTree(db.WebPages.Where(p => p.Active).OrderBy(p=>p.Order).ToArray());
        }

        private static RenderPage CreateTree(WebPage[] pages, WebPage current = null)
        {
            Dictionary<int, Node<WebPage>> lookup = new Dictionary<int, Node<WebPage>>();
            Dictionary<int?, List<Node<WebPage>>> children = new Dictionary<int?, List<Node<WebPage>>>();

            List<Node<WebPage>> roots = new List<Node<WebPage>>();

            foreach (var page in pages)
            {
                Node<WebPage> node = new Node<WebPage>();
                node.Data = page;
                node.Children = new List<Node<WebPage>>();

                lookup.Add(page.Id, node);

                if (page.ParentId != null)
                {
                    if (!children.ContainsKey(page.ParentId))
                    {
                        children[page.ParentId] = new List<Node<WebPage>>();
                    }
                    children[page.ParentId].Add(node);
                }

                if (page.ParentId == null)
                {
                    node.Parent = null;
                    roots.Add(node);
                }
            }

            foreach (var node in lookup.Values)
            {
                var page = node.Data;
                Node<WebPage> parent = null;
                if (page.ParentId != null)
                {
                    parent = lookup[(int)page.ParentId];
                }
                node.Parent = parent;
                if (children.ContainsKey(page.Id))
                {
                    node.Children = children[page.Id];
                }
            }

            var rpage = new RenderPage();
            rpage.Roots = roots;
            rpage.lookup = lookup;
            rpage.children = children;
            if (current != null)
            {
                rpage.Page = lookup[current.Id];
                rpage.Sidebar = GetFirstAncestor(rpage.Page);
                rpage.Ancestors = GetAncestors(rpage.Page);
                rpage.Title = rpage.Page.Data.Title;
            }
            return rpage;
        }

        public static List<Node<WebPage>> GetAncestors(Node<WebPage> current)
        {
            var ret = new List<Node<WebPage>>();
            ret.Add(current);
            while (current.Parent != null)
            {
                current = current.Parent;
                ret.Insert(0, current);
            }
            return ret;
        }

        private static Node<WebPage> GetFirstAncestor(Node<WebPage> current)
        {
            while (current.Parent != null)
            {
                current = current.Parent;
            }
            return current;
        }
    }
}