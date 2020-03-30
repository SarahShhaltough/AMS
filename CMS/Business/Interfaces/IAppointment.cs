using AMS.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Business.Interfaces
{
    public interface IAppointment
    {
        IEnumerable<Appointment> GetAppointments();
        Appointment GetAppointment(Guid id);
        string PutAppointment(Guid id, Appointment appointment);
        Appointment PostAppointment(Appointment appointment);
        Appointment DeleteAppointment(Guid id);
        bool AppointmentExists(Guid id);
    }
}
