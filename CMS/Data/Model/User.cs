using System;
using System.Collections.Generic;

namespace AMS.Data.Model
{
    public class User
    {
        // Attributes
        public Guid UserID { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public int UserPhoneNumber { get; set; }
        public bool UserStatus { get; set; }

        // Relations
        //public Guid BranchID { get; set; }
        public Branch Branch { get; set; }
        public ICollection<UserAppointment> UserAppointments { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }


    }
}
