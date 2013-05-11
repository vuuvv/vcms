using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using vuuvv.web.Models.ViewModel;

namespace vuuvv.web.Controllers
{
    public class AdminUploadController : Controller
    {
        //
        // GET: /AdminUpload/

        [HttpPost]
        public ActionResult Index(UploadFileModel file, string mode)
        {
            Dictionary<string, string> info = new Dictionary<string, string>();
            info["state"] = "未知错误";
            info["url"] = "";
            info["fileName"] = "";
            info["original"] = "";
            if (file.upfile != null && file.upfile.ContentLength > 0)
            {
                var path = string.Format("/static/media/upload/{0}/{1}/", file.path, DateTime.Now.ToString("yyyy-MM-dd"));
                var physical_path = Server.MapPath(path);
                if (!Directory.Exists(physical_path))
                    Directory.CreateDirectory(physical_path);
                string[] parts = file.upfile.FileName.Split('.');
                var ext =  "." + parts[parts.Length - 1].ToLower();
                var filename = System.Guid.NewGuid() + ext;
                path = Path.Combine(path, filename);
                physical_path = Path.Combine(physical_path, filename);
                file.upfile.SaveAs(physical_path);
                info["state"] = "SUCCESS";
                if (mode != null)
                {
                    info["url"] = path.Substring("/static/media/".Length);
                }
                else
                {
                    info["url"] = path;
                }
                info["fileName"] = filename;
                info["original"] = file.upfile.FileName;
            }
            return Json(info);
        }
    }
}
