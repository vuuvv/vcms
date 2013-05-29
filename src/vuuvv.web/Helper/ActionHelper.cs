using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;

using vuuvv.web.Framework.Security;

namespace vuuvv.web.Helper
{
    public class ActionHelper
    {
        public static Type[] GetAllSecurityController()
        {
            return ClassHelper.GetAllSubClass(typeof(SecurityController));
        }

        public static string[] GetAllAction(Type controller)
        {
            var actions = from action in new ReflectedControllerDescriptor(controller).GetCanonicalActions()
                          select String.Format("{0}.{1}.{2}", controller.Namespace, controller.Name, action.ActionName);
            return actions.ToArray();
        }
    }
}