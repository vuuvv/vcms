using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

using vuuvv.web.Helper;

namespace vuuvv.web.Models.ViewModel
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public bool IsValid
        {
            get
            {
                var db = new VDB();
                var sha1 = SHA1.Encode(Password);
                var users = db.Users.Where(u => u.Active && u.UserName == UserName && u.Password == sha1);
                return users.Count() != 0;
            }
        }
    }
}