using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vuuvv.web.Models.ViewModel
{
    public class UploadFileModel
    {
        public string path { get; set; }
        public HttpPostedFileWrapper upfile { get; set; }
    }

    public class UploadPixlrModel
    {
        public HttpPostedFile File { get; set; }
        public string Title { get; set; }
        public string State { get; set; }
        public string Type { get; set; }
    }
}