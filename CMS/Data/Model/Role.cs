using System;
using System.Collections.Generic;

namespace AMS.Data.Model
{
    public class Role
    {
        // Attributes
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
    
        // Relations
        public ICollection<User> Users { get; set; } 
    }
}
