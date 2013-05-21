using System.Web.Mvc;

namespace vuuvv.web.Areas.Mobile
{
    public class MobileAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Mobile";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "null",
                "Mobile/{controller}/{action}/{id}",
                new { controller="Main", action = "Index", id = UrlParameter.Optional },
                new string[] { "vuuvv.web.Areas.Mobile.Controllers" }
            );
        }
    }
}
