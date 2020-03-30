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
        Branch GetBranch(Guid id);
        string PutBranch(Guid id, Branch branch);
        Branch PostBranch(Branch branch);
        Branch DeleteBranch(Guid id);
        bool BranchExists(Guid id);
    }
}
