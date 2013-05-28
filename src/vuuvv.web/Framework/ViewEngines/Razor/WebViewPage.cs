using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace vuuvv.web.Framework.ViewEngines.Razor
{
    public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {
        public HelperResult RenderSection(string sectionName, Func<dynamic, HelperResult> defaultContent)
        {
            return IsSectionDefined(sectionName) ? RenderSection(sectionName) : defaultContent(new object());
        }

        public HelperResult RenderSection(string sectionName, string defaultContent)
        {
            return IsSectionDefined(sectionName) ? RenderSection(sectionName) : new HelperResult(
                writer =>
                {
                    writer.Write(defaultContent);
                }
            );
        }
    }
}