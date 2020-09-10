using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.Repository.Interface;

namespace WrokFlowWeb.Repository
{
    public class RoleApprovalMasterRepository : IRoleApprovalMasterRepository
    {

        private readonly WrokFlowWebEntityContext context;

        public RoleApprovalMasterRepository(WrokFlowWebEntityContext dbContext)
        {
            this.context = dbContext;
        }

        public async Task<List<RoleApprovalMaster>> GetRoleApprovalMasterList(long moduleId)
        {
           return await this.context.RoleApprovalMaster.Where(x => x.ModuleId == moduleId).ToListAsync();
        }

        
    }
}
