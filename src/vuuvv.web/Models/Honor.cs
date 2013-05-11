using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace vuuvv.web.Models
{
    public class HonorCategory
    {
        public virtual int Id { get; set; }
        [MaxLength(255)]
        public virtual string Name { get; set; }
        [MaxLength(255)]
        public virtual string Slug { get; set; }
        public virtual int Ordering { get; set; }
    }

    public class Honor
    {
        public virtual int Id { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual HonorCategory Category { get; set; }
        [MaxLength(255)]
        public virtual string Name { get; set; }
        [MaxLength(255)]
        public virtual string Year { get; set; }
        public virtual string Description { get; set; }
        [MaxLength(511)]
        public virtual string Image { get; set; }
        public virtual int Ordering { get; set; }
        public virtual bool Active { get; set; }
    }
}