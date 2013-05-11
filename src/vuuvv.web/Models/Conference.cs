using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace vuuvv.web.Models
{
    public class ConferenceColumn
    {
        public virtual int Id { get; set; }
        [MaxLength(255)]
        public virtual string Name { get; set; }

        public virtual List<ConferenceArticle> Articles { get; set; }
    }

    public class ConferenceArticle
    {
        public virtual int Id { get; set; }
        public virtual int ColumnId { get; set; }
        public virtual ConferenceColumn Column { get; set; }
        [MaxLength(255)]
        public virtual string Title { get; set; }
        [MaxLength(255)]
        public virtual string Name { get; set; }
        [MaxLength]
        public virtual string Content { get; set; }
    }
}