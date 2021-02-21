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
        Appointment GetAppointment(int id);
        string PutAppointment(int id, Appointment appointment);
        Appointment PostAppointment(Appointment appointment);
        Appointment DeleteAppointment(int id);
        bool AppointmentExists(int id);
    }
}
