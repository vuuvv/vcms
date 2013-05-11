using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

using vuuvv.web.Helper;

namespace vuuvv.web.Models
{
    public class User
    {
        public virtual int Id { get; set; }
        [MaxLength(255)]
        public virtual string UserName { get; set; }
        [MaxLength(255)]
        public virtual string RealName { get; set; }

        private string password;
        [MaxLength(255)]
        public virtual string Password {
            get
            {
                return password;
            }
            set
            {
                password = SHA1.Encode(value); 
            }
        }
        public virtual DateTime CreatedDate { get; set; }
        public virtual bool Active { get; set; }

        public User()
        {
            CreatedDate = DateTime.Now;
            Active = true;
        }

        public virtual IList<Role> Roles { get; set; }
    }

    public class Role
    {
        public virtual int Id { get; set; }
        [MaxLength(255)]
        public virtual string Name { get; set; }
        [MaxLength(255)]
        public virtual string Description { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual bool Active { get; set; }

        public virtual IList<User> Users { get; set; }
        public virtual IList<ActionPermission> ActionPermissions { get; set; }
        public virtual IList<MenuPermission> MenuPermissions { get; set; }
    }

    public class ActionPermission
    {
        public virtual int Id { get; set; }
        [MaxLength(255)]
        public virtual string Name { get; set; }
        [MaxLength(255)]
        public virtual string Description { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual bool Active { get; set; }

        public virtual IList<Role> Roles { get; set; }
    }

    public class MenuPermission
    {
        public virtual int Id { get; set; }
        public virtual int ParentId { get; set; }
        public virtual MenuPermission Parent { get; set; }
        [MaxLength(255)]
        public virtual string ActionName { get; set; }
        [MaxLength(255)]
        public virtual string ControllerName { get; set; }
        [MaxLength(255)]
        public virtual string Description { get; set; }
        [MaxLength(255)]
        public virtual string Icon1 { get; set; }
        [MaxLength(255)]
        public virtual string Icon2 { get; set; }
        public virtual bool IsLeaf { get; set; }
        [MaxLength(255)]
        public virtual string Url { get; set; }
        public virtual bool IsExt { get; set; }
        public virtual int Order { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual bool Active { get; set; }

        public virtual IList<Role> Roles { get; set; }
    }
}