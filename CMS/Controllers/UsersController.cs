using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AMS.Data;
using AMS.Data.Model;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using AMS.Data.DTO;

namespace AMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    [Authorize]

    public class UsersController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly ILogger<UsersController> _logger;

        public UsersController(AppDBContext context, ILogger<UsersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return _context.Users.Where(x => x.IsActive == true).OrderBy(x => x.UserFullName).ToList();
        }

        [HttpGet("byRole/{roleID}")]
        public ActionResult<IEnumerable<User>> GetUsers(int roleID)
        {
            return _context.Users.Where(x => x.RoleID == roleID && x.IsActive == true).OrderBy(x => x.UserFullName).ToList();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, User user)
        {
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {
            //user.BranchID = 1;
            user.RoleID = 3;
            user.IsActive = true;
            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction("GetUser", new { id = user.UserID }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public ActionResult<User> DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            user.IsActive = false;
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }

        [HttpGet("note-data/{id}")]
        public ActionResult<NoteDataDTO> GetPatientData(int id)
        {
            NoteDataDTO noteDataDTO = new NoteDataDTO();

            var userData = _context.Users.Where(x => x.UserID == id).Select(x => new { x.Allergies, x.FamilyHistory, x.PastHistory, x.SpecialPrecautions }).FirstOrDefault();
            var lastVisitNote = _context.Appointments.Where(x => x.UserID == id).ToList().LastOrDefault();
            noteDataDTO.Allergies = userData.Allergies;
            noteDataDTO.FamilyHistory = userData.FamilyHistory;
            noteDataDTO.PastHistory = userData.PastHistory;
            noteDataDTO.SpecialPrecautions = userData.SpecialPrecautions;
            noteDataDTO.Notes = lastVisitNote == null ? null : lastVisitNote.Notes;
            return noteDataDTO;

        }
    }
}
