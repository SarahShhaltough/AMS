using System;

namespace AMS.Data.Model
{
    public class UserRole
    {
        // Attributes
        public Guid UserRoleID { get; set; }

        // Relations
        //public Guid UserID { get; set; }
        public User User { get; set; }
        //public Guid RoleID { get; set; }
        public Role Role { get; set; }

    }
}
