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
    public class LookupsController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly ILogger<LookupsController> _logger;

        public LookupsController(AppDBContext context, ILogger<LookupsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Lookups
        [HttpGet]
        public ActionResult<IEnumerable<Lookup>> GetLookup()
        {
            return  _context.Lookup.ToList();
        }

        // GET: api/Lookups/5
        [HttpGet("{id}")]
        public ActionResult<Lookup> GetLookup(Guid id)
        {
            var lookup =  _context.Lookup.Find(id);

            if (lookup == null)
            {
                return NotFound();
            }

            return lookup;
        }

        // PUT: api/Lookups/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutLookup(Guid id, Lookup lookup)
        {
            if (id != lookup.LookupMajorID)
            {
                return BadRequest();
            }

            _context.Entry(lookup).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LookupExists(id))
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

        // POST: api/Lookups
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Lookup> PostLookup(Lookup lookup)
        {
            _context.Lookup.Add(lookup);
            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LookupExists(lookup.LookupMajorID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLookup", new { id = lookup.LookupMajorID }, lookup);
        }

        // DELETE: api/Lookups/5
        [HttpDelete("{id}")]
        public ActionResult<Lookup> DeleteLookup(Guid id)
        {
            var lookup =  _context.Lookup.Find(id);
            if (lookup == null)
            {
                return NotFound();
            }

            _context.Lookup.Remove(lookup);
            _context.SaveChanges();

            return lookup;
        }

        private bool LookupExists(Guid id)
        {
            return _context.Lookup.Any(e => e.LookupMajorID == id);
        }
    }
}
