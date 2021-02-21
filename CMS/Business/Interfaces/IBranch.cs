using AMS.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Business.Interfaces
{
    public interface IBranch
    {
        IEnumerable<Branch> GetBranches();
        Branch GetBranch(int id);
        string PutBranch(int id, Branch branch);
        Branch PostBranch(Branch branch);
        Branch DeleteBranch(int id);
        bool BranchExists(int id);
    }
}
