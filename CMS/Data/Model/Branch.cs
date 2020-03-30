using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Data.Model
{
    public class Branch
    {
        // Attributes
        public Guid BranchID { get; set; }
        public string BranchName { get; set; }
        public string BranchEmail { get; set; }
        public int BranchPhoneNumber { get; set; }
        public bool BranchStatus { get; set; }

        // Relations
       // public Guid CompanyID { get; set; }
        public Company Company { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Appointment> Appointments { get; set; }

    }
}
