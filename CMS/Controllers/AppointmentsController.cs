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
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace AMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    [Authorize]

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
        public ActionResult<Appointment> GetAppointment(int id)
        {
            var result = _appointment.GetAppointment(id);
            return result;
        }

        // GET: api/Appointments/5
        [HttpGet("all/{userId}")]
        public ActionResult<IEnumerable<Appointment>> GetAllAppointments(int userId)
        {
            var result = _appointment.GetAllAppointments(userId);
            return Ok(result);
        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public  IActionResult PutAppointment(int id, Appointment appointment)
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
        public ActionResult<Appointment> DeleteAppointment(int id)
        {
            var result = _appointment.DeleteAppointment(id);
            return result;
        }

        private bool AppointmentExists(int id)
        {
            var result = _appointment.AppointmentExists(id);
            return result;
        }
    }
}
