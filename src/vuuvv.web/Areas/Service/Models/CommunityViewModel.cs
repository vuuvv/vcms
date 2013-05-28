using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vuuvv.Domain.Entities.Service;

namespace vuuvv.web.Areas.Service.Models
{
    public class CommunityViewModel
    {
        public Carousel[] Carousel { get; set; }

        public static CommunityViewModel Create()
        {
            return new CommunityViewModel
            {
                Carousel = new Carousel[] {
                    new Carousel { Name = "", Link = "", Image = "/static/service/img/c1.png" },
                    new Carousel { Name = "", Link = "", Image = "/static/service/img/c2.png" },
                    new Carousel { Name = "", Link = "", Image = "/static/service/img/c3.png" }
                }
            };
        }
    }
}