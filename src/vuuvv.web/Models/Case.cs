using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace vuuvv.web.Models
{
    public class CaseCategory
    {
        public virtual int Id { get; set; }
        [MaxLength(255)]
        public virtual string Slug { get; set; }
        [MaxLength(255)]
        public virtual string Name { get; set; }
        public virtual int Ordering { get; set; }

        public virtual List<Case> cases { get; set; }
    }

    public class Case
    {
        public Case()
        {
            Active = true;
            CreatedDate = DateTime.Now;
            Ordering = 1000;
        }
        public virtual int Id { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual CaseCategory Category { get; set; }
        [MaxLength(255)]
        public virtual string Name { get; set; }
        [MaxLength]
        public virtual string Description { get; set; }
        [MaxLength(511)]
        public virtual string Image { get; set; }
        public virtual int Ordering { get; set; }
        public virtual bool Active { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }
}