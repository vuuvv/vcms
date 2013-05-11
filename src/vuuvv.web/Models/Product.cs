using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using vuuvv.web.Helper;

namespace vuuvv.web.Models
{
    public class ProductCategory
    {
        public virtual int Id { get; set; }
        public virtual int? ParentId { get; set; }
        public virtual ProductCategory Parent { get; set; }
        [MaxLength(255)]
        public virtual string Name { get; set; }
        [MaxLength(255)]
        public virtual string Url { get; set; }
        [MaxLength]
        public virtual string Description { get; set; }
        [MaxLength(255)]
        public virtual string Image { get; set; }
        [MaxLength(255)]
        public virtual string FeatureImage { get; set; }
        [MaxLength(1024)]
        public virtual string MetaDescription { get; set; }
        [MaxLength(1024)]
        public virtual string MetaKeywords { get; set; }
        public virtual bool Active { get; set; }

        public virtual List<Product> Products { get; set; }
        public virtual List<BannerImage> BannerImages { get; set; }

        public static Node<ProductCategory> CreateTree(ProductCategory[] categories, ProductCategory current)
        {
            Dictionary<int, Node<ProductCategory>> lookup = new Dictionary<int, Node<ProductCategory>>();
            Dictionary<int?, List<Node<ProductCategory>>> children = new Dictionary<int?, List<Node<ProductCategory>>>();

            List<Node<ProductCategory>> roots = new List<Node<ProductCategory>>();

            foreach (var category in categories)
            {
                Node<ProductCategory> node = new Node<ProductCategory>();
                node.Data = category;
                node.Children = new List<Node<ProductCategory>>();

                lookup.Add(category.Id, node);

                if (category.ParentId != null)
                {
                    if (!children.ContainsKey(category.ParentId))
                    {
                        children[category.ParentId] = new List<Node<ProductCategory>>();
                    }
                    children[category.ParentId].Add(node);
                }

                if (category.ParentId == null)
                {
                    node.Parent = null;
                    roots.Add(node);
                }
            }

            foreach (var node in lookup.Values)
            {
                var category = node.Data;
                Node<ProductCategory> parent = null;
                if (category.ParentId != null)
                {
                    parent = lookup[(int)category.ParentId];
                }
                node.Parent = parent;
                if (children.ContainsKey(category.Id))
                {
                    node.Children = children[category.Id];
                }
            }

            return lookup[current.Id];
        }
    }

    public class BannerImage
    {
        public virtual int Id { get; set; }
        [MaxLength(255)]
        public virtual string Image { get; set; }
        public virtual int ProductCategoryId { get; set; }
        public virtual ProductCategory Category { get; set; }
        public virtual int Ordering { get; set; }
    }

    public class Technology
    {
        public Technology()
        {
            Active = true;
        }
        public virtual int Id { get; set; }
        [MaxLength(255)]
        public virtual string Name { get; set; }
        [MaxLength]
        public virtual string Description { get; set; }
        [MaxLength(255)]
        public virtual string Image { get; set; }
        public virtual bool Active { get; set; }

        public virtual List<Product> Products { get; set; }
        public virtual List<Style> Styles { get; set; }
    }

    public class Product
    {
        public Product()
        {
            Categories = new List<ProductCategory>();
            CreatedDate = DateTime.Now;
            Active = true;
        }

        public virtual int Id { get; set; }
        [MaxLength(255)]
        public virtual string Sku { get; set; }
        [MaxLength(255)]
        public virtual string Name { get; set; }
        [MaxLength(255)]
        public virtual string Slug { get; set; }
        [MaxLength(255)]
        public virtual string Image { get; set; }
        [MaxLength(255)]
        public virtual string Thumbnail { get; set; }
        public virtual List<ProductCategory> Categories { get; set; }

        [MaxLength]
        public virtual string Summary { get; set; }
        [MaxLength]
        public virtual string Assembly { get; set; }
        [MaxLength]
        public virtual string Manual { get; set; }
        public virtual List<Technology> Technologies { get; set; }
        public virtual List<Style> Styles { get; set; }

        public virtual List<Property> properties { get; set; }

        public virtual int Ordering { get; set; }
        [MaxLength(255)]
        public virtual string Tags { get; set; }
        public virtual bool Active { get; set; }
        public virtual DateTime CreatedDate { get; set; }

        [NotMapped]
        public virtual string CategoriesName
        {
            get
            {
                var names = new List<string>();
                foreach (var category in Categories)
                {
                    names.Add(category.Name);
                }
                return string.Join(",", names); 
            }
        }
    }

    public class PropertyKey
    {
        public virtual int Id { get; set; }
        [MaxLength(255)]
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }

    public class Property
    {
        public virtual int Id { get; set; }
        public virtual int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual int PropertyKeyId { get; set; }
        public virtual PropertyKey Key { get; set; }
        [MaxLength(255)]
        public virtual string Value { get; set; }
        public virtual string Description { get; set; }
    }

    public class StyleCategory
    {
        public virtual int Id { get; set; }
        [MaxLength(255)]
        public virtual string Name { get; set; }
        [MaxLength(255)]
        public virtual string Slug { get; set; }
        public virtual bool Active { get; set; }

        public virtual List<Style> Styles { get; set; }
    }

    public class Style
    {
        public virtual int Id { get; set; }
        public virtual int StyleCategoryId { get; set; }
        public virtual StyleCategory Category { get; set; }
        [MaxLength(255)]
        public virtual string Name { get; set; }
        [MaxLength(255)]
        public virtual string Slug { get; set; }
        public virtual int Ordering { get; set; }
        public virtual bool Active { get; set; }
        [MaxLength]
        public virtual string Summary { get; set; }
        [MaxLength]
        public virtual string Introduce { get; set; }

        public virtual List<Technology> Technologies { get; set; }
        public virtual List<Product> Products { get; set; }

        public virtual List<StyleImage> Images { get; set; }
    }

    public class StyleImage
    {
        public virtual int Id { get; set; }
        [MaxLength(255)]
        public virtual string Image { get; set; }
        [MaxLength(255)]
        public virtual string Thumbnail { get; set; }
        public virtual int StyleId { get; set; }
        public virtual Style Style { get; set; }
    }
}