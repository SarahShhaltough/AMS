using AMS.Business.Interfaces;
using AMS.Data;
using AMS.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Business.Repositories
{
    public class BranchRepository: IBranch
    {
        private readonly AppDBContext _context;

        public BranchRepository(AppDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Branch> GetBranches()
        {
            return _context.Branches.ToList();
        }

        public Branch GetBranch(int id)
        {
            var branch = _context.Branches.Find(id);

            if (branch == null)
            {
                return null;
            }

            return branch;
        }

        public string PutBranch(int id, Branch branch)
        {
            if (id != branch.BranchID)
            {
                return null;
            }

            //_context.Entry(branch).State = EntityState.Modified;
            _context.Update(branch);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchExists(id))
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

        public Branch PostBranch(Branch branch)
        {
            _context.Branches.Add(branch);
            _context.SaveChanges();

            return branch;
        }

        public Branch DeleteBranch(int id)
        {
            var branch = _context.Branches.Find(id);
            if (branch == null)
            {
                return null;
            }

            _context.Branches.Remove(branch);
            _context.SaveChanges();

            return branch;
        }

        public bool BranchExists(int id)
        {
            return _context.Branches.Any(e => e.BranchID == id);
        }
    }
}
