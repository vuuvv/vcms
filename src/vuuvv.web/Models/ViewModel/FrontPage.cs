using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using vuuvv.web.Helper;
using vuuvv.web.Models;

namespace vuuvv.web.Models.ViewModel
{
    public class FrontPage
    {
        public string Title { get; set; }
        public int Column { get; set; }
        public List<Node<WebPage>> Roots { get; set; }
        public Node<WebPage> Sidebar { get; set; }
        public List<Node<WebPage>> Ancestors { get; set; }

        private Dictionary<int, Node<WebPage>> lookup;
        private Dictionary<int?, List<Node<WebPage>>> children;
    }
}