//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using AMS.Data;
//using AMS.Data.Model;
//using Microsoft.Extensions.Logging;

//namespace AMS.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CompaniesController : ControllerBase
//    {
//        private readonly AppDBContext _context;
//        private readonly ILogger<CompaniesController> _logger;

//        public CompaniesController(AppDBContext context, ILogger<CompaniesController> logger)
//        {
//            _context = context;
//            _logger = logger;
//        }

//        // GET: api/Companies
//        [HttpGet]
//        public ActionResult<IEnumerable<Company>> GetCompanies()
//        {
//            return  _context.Companies.ToList();
//        }

//        // GET: api/Companies/5
//        [HttpGet("{id}")]
//        public ActionResult<Company> GetCompany(int id)
//        {
//            var company =  _context.Companies.Find(id);

//            if (company == null)
//            {
//                return NotFound();
//            }

//            return company;
//        }

//        // PUT: api/Companies/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
//        // more details see https://aka.ms/RazorPagesCRUD.
//        [HttpPut("{id}")]
//        public IActionResult PutCompany(int id, Company company)
//        {
//            if (id != company.CompanyID)
//            {
//                return BadRequest();
//            }

//            _context.Entry(company).State = EntityState.Modified;

//            try
//            {
//                 _context.SaveChanges();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!CompanyExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Companies
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
//        // more details see https://aka.ms/RazorPagesCRUD.
//        [HttpPost]
//        public ActionResult<Company> PostCompany(Company company)
//        {
//            _context.Companies.Add(company);
//             _context.SaveChanges();

//            return CreatedAtAction("GetCompany", new { id = company.CompanyID }, company);
//        }

//        // DELETE: api/Companies/5
//        [HttpDelete("{id}")]
//        public ActionResult<Company> DeleteCompany(int id)
//        {
//            var company =  _context.Companies.Find(id);
//            if (company == null)
//            {
//                return NotFound();
//            }

//            _context.Companies.Remove(company);
//             _context.SaveChanges();

//            return company;
//        }

//        private bool CompanyExists(int id)
//        {
//            return _context.Companies.Any(e => e.CompanyID == id);
//        }
//    }
//}
