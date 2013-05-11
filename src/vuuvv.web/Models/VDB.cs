using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using vuuvv.web.Models;

namespace vuuvv.web.Models
{
    public class VDB : DbContext
    {
        public VDB()
            : base("vuuvv")
        {
        }

        public DbSet<WebPage> WebPages { get; set; }
        public DbSet<PressCategory> PressCategories { get; set; }
        public DbSet<Press> Press { get; set; }
        public DbSet<Magzine> Magzines { get; set; }
        public DbSet<MagzineYear> MagzineYears { get; set; }
        public DbSet<MagzineImage> MagzineImages { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyKey> PropertyKeys { get; set; }
        public DbSet<BannerImage> BannerImages { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<StyleCategory> StyleCategories { get; set; }
        public DbSet<StyleImage> StyleImages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<HonorCategory> HonorCategory { get; set; }
        public DbSet<Honor> Honor { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<CaseCategory> CaseCategory { get; set; }
        public DbSet<Case> Case { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Dealer> Dealer { get; set; }
        public DbSet<ConferenceColumn> ConferenceColumn { get; set; }
        public DbSet<ConferenceArticle> ConferenceArticles { get; set; }
        public DbSet<Slide> Slides { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ActionPermission> ActionPermissions { get; set; }
        public DbSet<MenuPermission> MenuPermissions { get; set; }
    }
}