using System;
using System.Collections.Generic;

namespace AMS.Data.Model
{
    public class Appointment
    {
        // Attributes
        public Guid AppointmentID { get; set; }
        public DateTime AppointmentStart { get; set; }
        public DateTime AppointmentEnd { get; set; }
        public bool Status { get; set; }

        // Relations
       // public Guid BranchID { get; set; }
        public Branch Branch { get; set; }
        public ICollection<UserAppointment> UserAppointments { get; set; }

    }
}
