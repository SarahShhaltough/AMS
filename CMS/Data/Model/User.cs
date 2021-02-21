using System;
using System.Collections.Generic;

namespace AMS.Data.Model
{
    public class User
    {
        // Attributes
        public int UserID { get; set; }
        public string UserFullName { get; set; }
        public string UserName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public int? UserPhoneNumber { get; set; }
        public string Job { get; set; }
        public string Education { get; set; }
        public string Allergies { get; set; }
        public string SpecialPrecautions { get; set; }
        public string PastHistory { get; set; }
        public string FamilyHistory { get; set; }
        public bool IsActive { get; set; }

        // Relations
        public int BranchID { get; set; }
        public Branch Branch { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }


    }
}
