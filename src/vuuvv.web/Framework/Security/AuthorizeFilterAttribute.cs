using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace vuuvv.web.Framework.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeFilterAttribute : ActionFilterAttribute
    {
        /*
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentException("filterContext");
            }
            var request = filterContext.HttpContext.Request;
            if (request.IsAuthenticated)
                return;
            filterContext.Result = new RedirectResult("/manage/adminlogin");
        }
        */
    }
}