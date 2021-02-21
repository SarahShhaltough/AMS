using System;
using System.Collections.Generic;

namespace AMS.Data.Model
{
    public class Branch
    {
        // Attributes
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string BranchEmail { get; set; }
        public int? BranchPhoneNumber { get; set; }
        public bool IsActive { get; set; }

        // Relations
       // public int CompanyID { get; set; }
        //public Company Company { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Appointment> Appointments { get; set; }

    }
}
