using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WrokFlowWeb.Repository.Interface
{
    public interface IRoleApprovalMasterRepository
    {
        Task<List<Database.RoleApprovalMaster>> GetRoleApprovalMasterList(long moduleId);
    }
}
