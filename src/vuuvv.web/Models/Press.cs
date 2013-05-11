using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vuuvv.web.Models
{
    public class PressCategory
    {
        public virtual int Id { get; set; }
        [MaxLength(255)]
        public virtual string Name { get; set; }
        [MaxLength(255)]
        public virtual string Slug { get; set; }
    }

    public class Press
    {
        public virtual int Id { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual PressCategory Category { get; set; }
        [MaxLength(255)]
        public virtual string Title { get; set; }
        [MaxLength(255)]
        public virtual string SubTitle { get; set; }
        [MaxLength(255)]
        public virtual string Author { get; set; }
        [MaxLength(255)]
        public virtual string PressFrom { get; set; }
        [MaxLength(511)]
        public virtual string Summary { get; set; }
        [MaxLength]
        public virtual string Content { get; set; }
        public virtual bool Active { get; set; }
        [MaxLength(511)]
        public virtual string Thumbnail { get; set; }
        [MaxLength(511)]
        public virtual string Tags { get; set; }
        [Timestamp]
        public virtual DateTime CreatedDate { get; set; }
        public virtual int TopOrder { get; set; }

        [NotMapped]
        public virtual List<string> TagList
        {
            get
            {
                if (Tags == null || Tags == "")
                    return new List<string>();
                return Tags.Split(',', ' ', '，').ToList();
            }
        }
    }
}