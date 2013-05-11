using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

using vuuvv.web.Helper;

namespace vuuvv.web.Models
{
    public class Area
    {
        public virtual int Id { get; set; }
        public virtual int? ParentId { get; set; }
        public virtual Area Parent { get; set; }
        [MaxLength(255)]
        public virtual string Name { get; set; }
        [MaxLength]
        public virtual string boundary { get; set; }

        public virtual List<Area> Children { get; set; }
        public virtual List<Dealer> Dealers { get; set; }

        public static Node<Area> CreateTree(Area[] areas, Area current)
        {
            Dictionary<int, Node<Area>> lookup = new Dictionary<int, Node<Area>>();
            Dictionary<int?, List<Node<Area>>> children = new Dictionary<int?, List<Node<Area>>>();

            List<Node<Area>> roots = new List<Node<Area>>();

            foreach (var area in areas)
            {
                Node<Area> node = new Node<Area>();
                node.Data = area;
                node.Children = new List<Node<Area>>();

                lookup.Add(area.Id, node);

                if (area.ParentId != null)
                {
                    if (!children.ContainsKey(area.ParentId))
                    {
                        children[area.ParentId] = new List<Node<Area>>();
                    }
                    children[area.ParentId].Add(node);
                }

                if (area.ParentId == null)
                {
                    node.Parent = null;
                    roots.Add(node);
                }
            }

            foreach (var node in lookup.Values)
            {
                var area = node.Data;
                Node<Area> parent = null;
                if (area.ParentId != null)
                {
                    parent = lookup[(int)area.ParentId];
                }
                node.Parent = parent;
                if (children.ContainsKey(area.Id))
                {
                    node.Children = children[area.Id];
                }
            }

            return lookup[current.Id];
        }
    }

    public class Dealer
    {
        public virtual int Id { get; set; }
        public virtual int AreaId { get; set; }
        public virtual Area MyArea { get; set; }
        public virtual int Area { get; set; }
        [MaxLength(255)]
        public virtual string Name { get; set; }
        [MaxLength(255)]
        public virtual string Address { get; set; }
        [MaxLength(255)]
        public virtual string Contact { get; set; }
        [MaxLength(255)]
        public virtual string Tel { get; set; }
        [MaxLength(255)]
        public virtual string Mobile { get; set; }
        [MaxLength(255)]
        public virtual string Fax { get; set; }
        [MaxLength(255)]
        public virtual string Website { get; set; }
        [MaxLength(255)]
        public virtual string Zipcode { get; set; }
        [MaxLength(255)]
        public virtual string latitude { get; set; }
        [MaxLength(255)]
        public virtual string longitude { get; set; }
        public virtual bool Active { get; set; }
    }
}