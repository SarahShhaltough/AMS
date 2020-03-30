using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AMS.Data;
using AMS.Data.Model;
using Microsoft.Extensions.Logging;
using AMS.Business.Interfaces;

namespace AMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly ILogger<AppointmentsController> _logger;
        private readonly IAppointment _appointment;

        public AppointmentsController(ILogger<AppointmentsController> logger, IAppointment appointment)
        {
            _logger = logger;
            _appointment = appointment;
        }

        // GET: api/Appointments
        [HttpGet]
        public ActionResult<IEnumerable<Appointment>> GetAppointments()
        {
            var result = _appointment.GetAppointments();
            return Ok(result);
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public ActionResult<Appointment> GetAppointment(Guid id)
        {
            var result = _appointment.GetAppointment(id);
            return result;
        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public  IActionResult PutAppointment(Guid id, Appointment appointment)
        {
            var result = _appointment.PutAppointment(id, appointment);
            if (result.Contains("successed"))
            {
                return Ok();
            } 
            else 
            {
                return BadRequest();
            }
        }

        // POST: api/Appointments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Appointment> PostAppointment(Appointment appointment)
        {
            var result = _appointment.PostAppointment(appointment);
            return CreatedAtAction("GetAppointment", new { id = result.AppointmentID }, result);
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public ActionResult<Appointment> DeleteAppointment(Guid id)
        {
            var result = _appointment.DeleteAppointment(id);
            return result;
        }

        private bool AppointmentExists(Guid id)
        {
            var result = _appointment.AppointmentExists(id);
            return result;
        }
    }
}
