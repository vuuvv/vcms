using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace vuuvv.web.Models
{
    public class Slide
    {
        public Slide()
        {
            Active = true;
        }
        public virtual int Id { get; set; }
        [MaxLength(255)]
        public virtual string Title { get; set; }
        [MaxLength]
        public virtual string Description { get; set; }
        [MaxLength(511)]
        public virtual string Image { get; set; }
        [MaxLength(511)]
        public virtual string Link { get; set; }
        public virtual int Ordering { get; set; }
        public virtual bool Active { get; set; }
    }
}