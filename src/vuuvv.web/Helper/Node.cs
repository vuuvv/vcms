using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vuuvv.web.Helper
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Parent { get; set; }
        public List<Node<T>> Children { get; set; }

        public bool HasChildren
        {
            get
            {
                return Children.Count > 0;
            }
        }

        public List<Node<T>> Leafs
        {
            get
            {
                var ret = new List<Node<T>>();

                if (!HasChildren)
                    return ret;

                foreach (var c in Children)
                {
                    if (!c.HasChildren)
                        ret.Add(c);
                    else
                        ret = ret.Union(c.Leafs).ToList();
                }
                return ret;
            }
        }
    }
}