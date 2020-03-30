using System;

namespace AMS.Data.Model
{
    public class UserAppointment
    {
        // Attributes 
        public Guid UserAppointmentID { get; set; }
        // RoleID used here as attribute to keep tracking of appointment-user role history 
        // "getting role at appointment time", in case the role has been changed the value will be accurate
        public Guid RoleID { get; set; }
        
        // Relations
        //public Guid UserID { get; set; }
        public User User { get; set; }

        //public Guid AppointmentID { get; set; }
        public Appointment Appointment { get; set; }


    }
}
