using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vuuvv.Domain.Entities.Service;

namespace vuuvv.web.Areas.Service.Models
{
    public class PageLayout
    {
        public Navigation[] Navigations { get; set; }

        public static PageLayout Create()
        {
            return new PageLayout
            {
                Navigations = new Navigation[] {
                    new Navigation { Title = "走进社区", Link = "" },
                    new Navigation { Title = "会员专区", Link = "" },
                    new Navigation { Title = "互动专区", Link = "" },
                    new Navigation { Title = "动态公告", Link = "" },
                    new Navigation { Title = "网点查询", Link = "" },
                    new Navigation { Title = "客服咨询", Link = "" },
                    new Navigation { Title = "卫浴大讲堂", Link = "" },
                    new Navigation { Title = "关于我们", Link = "" }
                }
            };
        }
    }
}