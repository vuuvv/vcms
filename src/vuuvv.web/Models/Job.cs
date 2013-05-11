using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace vuuvv.web.Models
{
    public class Job
    {
        public virtual int Id { get; set; }
        [MaxLength(255)]
        public virtual string Name { get; set; }
        [MaxLength(255)]
        public virtual string Experience { get; set; }
        [MaxLength(255)]
        public virtual string Education { get; set; }
        [MaxLength(255)]
        public virtual string Professional { get; set; }
        [MaxLength(255)]
        public virtual string Age { get; set; }
        [MaxLength(255)]
        public virtual string Gender { get; set; }
        [MaxLength]
        public virtual string Description { get; set; }
        public virtual DateTime PublishDate { get; set; }
        public virtual DateTime? ExpiredDate { get; set; }
    }
}