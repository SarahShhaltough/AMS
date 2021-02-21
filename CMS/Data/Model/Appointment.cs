using System;
using System.Collections.Generic;

namespace AMS.Data.Model
{
    public class Appointment
    {
        // Attributes
        public int AppointmentID { get; set; }
        //public DateTime AppointmentStart { get; set; }
        //public DateTime AppointmentEnd { get; set; }
        //public bool Status { get; set; }
        public string CO { get; set; }
        public string Examination { get; set; }
        public string GE { get; set; }
        public string Investigations { get; set; }
        public string Plan { get; set; }
        public string Treatment { get; set; }
        public string Notes { get; set; }

        // Relations
        // public int BranchID { get; set; }
        public Branch Branch { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }

    }
}
