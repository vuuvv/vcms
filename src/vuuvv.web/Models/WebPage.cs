using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using vuuvv.web.Helper;

namespace vuuvv.web.Models
{
    public class WebPage
    {
        public virtual int Id { get; set; }
        public virtual int? ParentId { get; set; }
        public virtual WebPage Parent { get; set; }
        [MaxLength(255)]
        public virtual string Url { get; set; }
        [MaxLength(255)]
        public virtual string Title { get; set; }
        [MaxLength]
        public virtual string Content { get; set; }
        [MaxLength(1024)]
        public virtual string MetaDescription { get; set; }
        [MaxLength(1024)]
        public virtual string MetaKeywords { get; set; }
        public virtual int Order { get; set; }
        public virtual int Col { get; set; }
        public virtual bool Active { get; set; }
        public virtual bool InNavigation { get; set; }
        public virtual bool HasBanner { get; set; }

        [NotMapped]
        public virtual string Slug
        {
            get
            {
                var index = Url.LastIndexOf('/');
                if (index < 0)
                    return Url;
                else
                    return Url.Substring(index + 1);
            }
        }

    }
}