using System;
using System.Collections.Generic;

namespace AMS.Data.Model
{
    public class Role
    {
        // Attributes
        public Guid RoleID { get; set; }
        public string RoleName { get; set; }
    
        // Relations
        public ICollection<UserRole> UserRoles { get; set; } 
    }
}
