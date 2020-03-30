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
    public class BranchesController : ControllerBase
    {
        private readonly ILogger<BranchesController> _logger;
        private readonly IBranch _branch;

        public BranchesController(ILogger<BranchesController> logger, IBranch branch)
        {
            _logger = logger;
            _branch = branch;
        }

        // GET: api/Branches
        [HttpGet]
        public ActionResult<IEnumerable<Branch>> GetBranches()
        {
            var result = _branch.GetBranches();
            return Ok(result);
        }

        // GET: api/Branches/5
        [HttpGet("{id}")]
        public ActionResult<Branch> GetBranch(Guid id)
        {
            var result = _branch.GetBranch(id);
            return result;
        }

        // PUT: api/Branches/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutBranch(Guid id, Branch branch)
        {
            var result = _branch.PutBranch(id, branch);
            if (result.Contains("successed"))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Branches
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Branch> PostBranch(Branch branch)
        {
            var result = _branch.PostBranch(branch);
            return CreatedAtAction("GetBranch", new { id = result.BranchID }, result);
        }

        // DELETE: api/Branches/5
        [HttpDelete("{id}")]
        public ActionResult<Branch> DeleteBranch(Guid id)
        {
            var result = _branch.DeleteBranch(id);
            return result;
        }

        private bool BranchExists(Guid id)
        {
            var result = _branch.BranchExists(id);
            return result;
        }
    }
}
