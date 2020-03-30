using AMS.Business.Interfaces;
using AMS.Data;
using AMS.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Business.Repositories
{
    public class AppointmentRepository : IAppointment
    {
        private readonly AppDBContext _context;

        public AppointmentRepository(AppDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return _context.Appointments.ToList();
        }

        public Appointment GetAppointment(Guid id)
        {
            var appointment = _context.Appointments.Find(id);
            if (appointment == null)
            {
                return null;
            }
            return appointment;
        }

        public string PutAppointment(Guid id, Appointment appointment)
        {
            if (id != appointment.AppointmentID)
            {
                return null;
            }
            //_context.Entry(appointment).State = EntityState.Modified;
            _context.Update(appointment);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return "successed";
        }

        public Appointment PostAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            return appointment;
        }

        public Appointment DeleteAppointment(Guid id)
        {
            var appointment = _context.Appointments.Find(id);
            if (appointment == null)
            {
                return null;
            }

            _context.Appointments.Remove(appointment);
            _context.SaveChanges();

            return appointment;
        }

        public bool AppointmentExists(Guid id)
        {
            return _context.Appointments.Any(e => e.AppointmentID == id);
        }
    }
}
