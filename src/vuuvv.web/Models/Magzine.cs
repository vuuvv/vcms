using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vuuvv.web.Models
{
    public class MagzineYear
    {
        public virtual int Id { get; set; }
        public virtual int Year { get; set; }
        public virtual List<Magzine> Magzines { get; set; }
    }

    public class Magzine
    {
        public virtual int Id { get; set; }
        public virtual int MagzineYearId { get; set; }
        public virtual MagzineYear Year { get; set; }
        [MaxLength(255)]
        public virtual string Name { get; set; }
        [MaxLength(255)]
        public virtual string Slug { get; set; }
        public virtual int Ordering { get; set; }
        public virtual bool Active { get; set; }
        [MaxLength(511)]
        public virtual string Thumbnail { get; set; }
        public virtual List<MagzineImage> Images { get; set; }

        [NotMapped]
        public virtual string Flash
        {
            get
            {
                return string.Format("/static/media/upload/magzine/magzine.swf?xml={0}/pages.xml", Slug);
            }
        }
    }

    public class MagzineImage
    {
        public virtual int Id { get; set; }
        public virtual int Page { get; set; }
        [MaxLength(511)]
        public virtual string Image { get; set; }
        public virtual int MagzineId { get; set; }
        public virtual Magzine Magzine { get; set; }
    }
}