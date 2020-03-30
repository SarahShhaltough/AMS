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

namespace AMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly ILogger<RolesController> _logger;

        public RolesController(AppDBContext context, ILogger<RolesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Roles
        [HttpGet]
        public ActionResult<IEnumerable<Role>> GetRoles()
        {
            return  _context.Roles.ToList();
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public ActionResult<Role> GetRole(Guid id)
        {
            var role =  _context.Roles.Find(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutRole(Guid id, Role role)
        {
            if (id != role.RoleID)
            {
                return BadRequest();
            }

            _context.Entry(role).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Roles
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Role> PostRole(Role role)
        {
            _context.Roles.Add(role);
             _context.SaveChanges();

            return CreatedAtAction("GetRole", new { id = role.RoleID }, role);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public ActionResult<Role> DeleteRole(Guid id)
        {
            var role =  _context.Roles.Find(id);
            if (role == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(role);
            _context.SaveChanges();

            return role;
        }

        private bool RoleExists(Guid id)
        {
            return _context.Roles.Any(e => e.RoleID == id);
        }
    }
}
